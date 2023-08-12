using Infrastructure.Services;
using Infrastructure.States;
using UI;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine { get; set; }
        
        public Game(ICoroutineRunner coroutineRunner, LoadingScreen screen)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), screen, AllServices.Container);
        }
    }
}