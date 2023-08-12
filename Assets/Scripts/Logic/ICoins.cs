using System;

namespace Logic
{
    public interface ICoins
    {
        event Action CoinsChanged;
        int Current { get; set; }
        int Max { get; set; }

        void CmdPickup(int value);
    }
}