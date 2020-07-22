using System;
using System.Collections.Generic;

namespace BattleCityRoyalJS_v3.Desktop
{
    public class MM : IManager
    {
        private List<IManager> managers;
        private static MM mm;

        private MM()
        {
            managers = new List<IManager>();
        }

        public void AddManager(IManager manager)
        {
            managers.Add(manager);
        }

        public IManager GetManager<T>()
        {
            return managers.Find((obj) => obj.GetType() == typeof(T));
        }

        public static MM Instance
        {
            get
            {
                if (mm == null)
                {
                    mm = new MM();
                }

                return mm;
            }
        }
    }
}
