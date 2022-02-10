using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        T Get<T>(string key); //send me the equivalent of the key from the cache.
        object Get(string key);//same as above.
        bool IsAdd(string key); //to check if it exists in the cache..
        void Remove(string key); //remove from the cache.
        void RemoveByPattern(string pattern); //remove the value that contains a specific regular expression from the cache.
    }
}
