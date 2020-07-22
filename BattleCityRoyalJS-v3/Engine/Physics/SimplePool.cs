using System;
namespace BattleCityRoyalJS_v3.Desktop.Engine.Physics
{
    public class SimplePool<T> : IPool<T> where T : new()
    {
        private T[] simplePool;
        private int size;
        private int index;

        public SimplePool(int size)
        {
            this.size = size;
            index = 0;

            simplePool = new T[size];

            for (int i = 0; i < size; i++)
            {
                simplePool[i] = new T();
            }
        }


        public T RequestPoolItem()
        {
            T selectedPool = simplePool[index];

            index = (index + 1) % size;

            return selectedPool;
        }
    }
}
