using System;
using System.Collections.Generic;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class PoolManager : IManager
    {
        private List<IPool<Object>> pools;

        public PoolManager()
        {
            pools = new List<IPool<Object>>();
        }

        public void AddPool(IPool<Object> pool)
        {
            pools.Add(pool);
        }

        public IPool<Object> GetPool<T>()
        {
            return pools.Find((obj) => obj.GetType() == typeof(T));
        }
    }
}
