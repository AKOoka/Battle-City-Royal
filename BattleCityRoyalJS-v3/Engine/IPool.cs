using System;
namespace BattleCityRoyalJS_v3.Desktop
{
    public interface IPool<T> where T : new()
    {
        T RequestPoolItem();
    }
}
