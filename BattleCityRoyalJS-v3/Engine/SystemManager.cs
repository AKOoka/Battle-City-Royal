using System;
using System.Collections.Generic;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class SystemManager : IManager
    {
        private List<ISystem> systems;

        public SystemManager()
        {
            systems = new List<ISystem>();
        }

        public void AddSystem(ISystem system)
        {
            systems.Add(system);
        }

        public ISystem GetSystem<T>()
        {
            return systems.Find((obj) => obj.GetType() == typeof(T));
        }
    }
}
