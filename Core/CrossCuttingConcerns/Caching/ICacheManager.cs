using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //cache ten mi yoksa db den mi getireceğiz? buna karar verirken önce cache te var mı diye kontrol ederiz.Bu yüzden IsAdd var
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern); 
    }
}
