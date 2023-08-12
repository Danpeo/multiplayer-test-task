using UnityEngine;

namespace Infrastructure.Services.Random
{
    public interface IRandomService : IService
    {
        Color RandomColor();
        Color[] GetAvailableColors();
    }
}