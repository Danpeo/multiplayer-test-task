using UnityEngine;

namespace Infrastructure.Services.Random
{
    public class RandomService : IRandomService
    {
        private readonly Color[] _predefinedColors =
        {
            Color.red,
            Color.green,
            Color.blue,
            Color.white,
        };

        public Color RandomColor()
        {
            int randomIndex = UnityEngine.Random.Range(0, _predefinedColors.Length);
            return _predefinedColors[randomIndex];
        }
        
        public Color[] GetAvailableColors() => 
            _predefinedColors;
    }
}