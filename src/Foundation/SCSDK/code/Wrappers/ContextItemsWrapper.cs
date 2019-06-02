using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public class ContextItemsWrapper : IContextItemsWrapper
    {
        private IDictionary _contextItems;
        private IDictionary ContextItems
        {
            get
            {
                if (_contextItems == null && HttpContext.Current?.Items != null)
                    _contextItems = HttpContext.Current.Items;

                return _contextItems;
            }
            set
            {
                _contextItems = value;
            } 
        }

        public ContextItemsWrapper()
        {
            if (_contextItems == null && HttpContext.Current?.Items != null)
                ContextItems = HttpContext.Current.Items;
        }

        public bool KeyExists(string contextKey)
        {
            return ContextItems?[contextKey] != null;
        }

        public T Get<T>(string contextKey)
        {
            if (!KeyExists(contextKey))
                return default(T);
            return (T)ContextItems[contextKey];
        }

        public void Add<T>(string contextKey, T value)
        {
            if (ContextItems == null) return;
            ContextItems[contextKey] = value;
        }

        public void Remove(string contextKey)
        {
            ContextItems?.Remove(contextKey);
        }
    }
}