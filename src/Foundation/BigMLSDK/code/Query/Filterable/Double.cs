namespace SitecoreCognitiveServices.Foundation.BigMLSDK.Meta
{
    public class Double : Object
    {
        Double(string name):base(name)
        {
        }

        public static Bool operator ==(Double c1, double c2)
        {
            return default(Bool);
        }

        public static Bool operator !=(Double c1, double c2)
        {
            return default(Bool);
        }

        public static Bool operator >(Double c1, double c2)
        {
            return default(Bool);
        }

        public static Bool operator <(Double c1, double c2)
        {
            return default(Bool);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}