using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;

namespace SitecoreCognitiveServices.Foundation.BigMLSDK
{
    public partial class Model
    {
        /// <summary>
        /// A tree-like recursive structure representing the model.
        /// </summary>
        public class Node
        {
            readonly dynamic _node;
            internal Node(JObject json)
            {
                _node = json;
            }

            internal Expression Expression(Dictionary<string, ParameterExpression> parameters)
            {
                var result = System.Linq.Expressions.Expression.Constant(Output) as Expression;

                return Children.Aggregate(result,
                                          (current, child) =>
                                          System.Linq.Expressions.Expression.Condition(
                                              child.Predicate.Expression(parameters), child.Expression(parameters),
                                              current));
            }

            internal Expression ConfidVal(Dictionary<string, ParameterExpression> parameters)
            {
                var confidence = System.Linq.Expressions.Expression.Constant(Confidence) as Expression;

                return Children.Aggregate(confidence,
                                          (current, child) =>
                                          System.Linq.Expressions.Expression.Condition(
                                              child.Predicate.Expression(parameters), child.ConfidVal(parameters),
                                              current));
            }

            internal Expression ComplexResult(Dictionary<string, ParameterExpression> parameters)
            {
                ResultNode rn = new ResultNode();
                rn.Output = Output;
                rn.Confidence = Confidence;
                rn.Count = Count;

                var result = System.Linq.Expressions.Expression.Constant(rn) as Expression;

                return Children.Aggregate(result,
                                          (current, child) =>
                                          System.Linq.Expressions.Expression.Condition(
                                              child.Predicate.Expression(parameters), child.ComplexResult(parameters),
                                              current));
            }


            /// <summary>
            /// Array of child Node Objects.
            /// </summary>
            List<Node> _children;
            public IEnumerable<Node> Children
            {
                get
                {
                    if (_children == null)
                    {
                        _children = new List<Node>();
                        if (_node.children != null) {
                            foreach (JObject child in _node.children)
                            {
                                _children.Add(new Node(child));

                            }
                        }
                        //_children = (_node.children as JObject).Select(child => new Node(child));
                    }
                    return _children;
                }
            }


            /// <summary>
            /// The confidence of the output with more weight in this node.
            /// </summary>
            public float Confidence
            {
                get { return _node.confidence; }
            }

            /// <summary>
            /// Number of instances classified by this node.
            /// </summary>
            public int Count
            {
                get { return _node.count; }
            }


            /// <summary>
            /// Distribution of the objective field at this node.
            /// </summary>
            public JArray Distribution
            {
                get
                {
                    if (_node["objective_summary"].ContainsKey("categories"))
                    {
                        return _node["objective_summary"]["categories"];
                    }
                    else if (_node["objective_summary"].ContainsKey("counts"))
                    {
                        return _node["objective_summary"]["counts"];
                    }
                    else if (_node["objective_summary"].ContainsKey("bins"))
                    {
                        return _node["objective_summary"]["bins"];
                    }
                    else
                    {
                        // Old splits summary case
                        return new JArray();
                    }
                }
            }

            /// <summary>
            /// Prediction at this node (number or string)
            /// </summary>
            public dynamic Output
            {
                get { return _node.output.Value; }
            }


            private Predicate _predicate;
            /// <summary>
            /// Predicate structure to make a decision at this node.
            /// </summary>
            /// 
            public Predicate Predicate
            {
                get {
                    if (_predicate == null)
                    {
                        _predicate = new Predicate(_node.predicate);
                    }
                    return _predicate;
                }
            }

            public Dictionary<object, object> toDictionary(bool withDistribution = true)
            {
                Dictionary<object, object> dictionaryResult = new Dictionary<object, object>();
                dictionaryResult.Add("prediction", this.Output);
                dictionaryResult.Add("confidence", this.Confidence);
                dictionaryResult.Add("count", this.Count);

                if (withDistribution) { 
                    dictionaryResult.Add("distribution", this.Distribution);
                }
                else
                {
                    dictionaryResult.Add("distribution", new JObject());
                }

                return dictionaryResult;
            }

            public override string ToString()
            {
                return Output + " " + Confidence.ToString() +
                        " Distribution:" + _node.objective_summary.ToString();
            }
        }
    }
}