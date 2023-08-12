using System;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject PlayerGameObject { get; }
        event Action PlayerCreated;
        GameObject CreatePlayer(GameObject at);
        GameObject CreateHud();
    }
}