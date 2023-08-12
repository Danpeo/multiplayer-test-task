using Logic;
using Mirror;
using UnityEngine;

namespace Loot
{
    public class Coin : NetworkBehaviour
    {
        [SerializeField] private int value = 2;
        private void OnTriggerEnter2D(Collider2D other)
        {
            var coin = other.gameObject.GetComponent<ICoins>();
            AddCoin(coin);
        }
        
        
        private void AddCoin(ICoins coin)
        {
            if (coin != null)
            {
                coin.CmdPickup(value);
                Destroy(gameObject);
            }
        }
    }
}