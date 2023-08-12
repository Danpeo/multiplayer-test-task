using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.Random;
using Mirror;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerColor : NetworkBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;

        [SyncVar(hook = nameof(OnSpriteColorChanged))]
        private Color _syncedColor = Color.white;

        private IRandomService _randomService;

        private static readonly List<Color> _usedColors = new();

        public void Awake() => 
            _randomService = AllServices.Container.Single<IRandomService>();

        public void Start()
        {
            if (isLocalPlayer) 
                CmdRandomizeSpriteColor();
        }

        [Command]
        private void CmdRandomizeSpriteColor()
        {
            Color randomColor = GetRandomUnusedColor();
            _syncedColor = randomColor;
            _usedColors.Add(randomColor);
        }

        private Color GetRandomUnusedColor()
        {
            var availableColors = new List<Color>(_randomService.GetAvailableColors());
            availableColors.RemoveAll(color => _usedColors.Contains(color));
            
            if (availableColors.Count == 0)
            {
                return Color.white;
            }

            int randomIndex = Random.Range(0, availableColors.Count);
            return availableColors[randomIndex];
        }

        [ClientRpc]
        private void RpcRandomizeSpriteColor(Color color) => 
            _sprite.color = color;

        private void OnSpriteColorChanged(Color oldValue, Color newValue)
        {
            _sprite.color = newValue;

            if (!isLocalPlayer) 
                RpcRandomizeSpriteColor(newValue);
        }
    }
}