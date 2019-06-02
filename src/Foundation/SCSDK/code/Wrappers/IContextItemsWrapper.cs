using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface IContextItemsWrapper
    {
        /// <summary>
        /// returns true if a given key exists
        /// </summary>
        /// <param name="contextKey"></param>
        /// <returns></returns>
        bool KeyExists(string contextKey);

        /// <summary>
        /// Get a value from the session as a specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contextKey"></param>
        /// <returns></returns>
        T Get<T>(string contextKey);
        /// <summary>
        /// Adds an object to the session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contextKey"></param>
        /// <param name="value"></param>
        void Add<T>(string contextKey, T value);
        /// <summary>
        /// Removes an object from the session
        /// </summary>
        /// <param name="contextKey"></param>
        void Remove(string contextKey);
    }
}