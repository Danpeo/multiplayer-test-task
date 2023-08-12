using Infrastructure.Services.Factory;
using Infrastructure.Services.Network;
using Mirror;
using Player;
using UI;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingScreen _screen;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingScreen screen,
            IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _screen = screen;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _screen.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _screen.Hide();

        private void OnLoaded()
        {
            InitializeHud();
            
            if (NetworkService.IsHost)
                NetworkManager.singleton.StartHost();
            else
                NetworkManager.singleton.StartClient();
            
            _stateMachine.Enter<GameLoopState>();
        }
        
        private void InitializeHud()
        {
            _gameFactory.CreateHud();
            
        }
        
    }
}