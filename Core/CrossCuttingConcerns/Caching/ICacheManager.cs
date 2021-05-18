using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);//Cache den getirme işlemleri
        void Add(string key,object data, int duration); //Cache ekleme işlemi
        bool IsAdd(string key);//Cache e eklenmiş mi
        void Remove(string key);//Cache'ten sil
        void RemoveByPattern(string pattern);//Get ile başlayanları sil gibi

    }
}
