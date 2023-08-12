using System;
using Logic;
using Mirror;
using UnityEngine;

namespace Player
{
    public class PlayerCoins : NetworkBehaviour, ICoins
    {
        public event Action CoinsChanged;
        
        [SyncVar(hook = nameof(OnCoinsChanged))]
        [SerializeField] 
        private int _current;
        
        public int Current
        {
            get => _current;
            set
            {
                if (_current != value)
                {
                    _current = value;
                    CoinsChanged?.Invoke();
                }
            }
        }

        [SerializeField] private int _max;

        public int Max
        {
            get => _max;
            set => _max = value;
        }

        [Command]
        public void CmdPickup(int value)
        {
            if (Current >= Max)
                return;

            Current += value;
        }
        
        private void OnCoinsChanged(int oldValue, int newValue)
        {
            Current = newValue;
            CoinsChanged?.Invoke();
        }
    }
}