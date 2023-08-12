using System;
using Data;
using Infrastructure;
using Infrastructure.Services.Network;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lobby
{
    public class Lobby : MonoBehaviour
    {
        private const string SceneToLoad = "Scenes/Loading";
        [SerializeField] private TMP_InputField _inputNameText;

        private SceneLoader _sceneLoader;

        public void StartHost()
        {
            InitializePlayer();

            NetworkService.StartHost();
            SceneManager.LoadSceneAsync(SceneToLoad);
        }

        public void StartClient()
        {
            InitializePlayer();

            NetworkService.StartClient();
            SceneManager.LoadSceneAsync(SceneToLoad);
        }

        private void InitializePlayer()
        {
            NetworkService.PlayerName = !string.IsNullOrEmpty(_inputNameText.text)
                ? _inputNameText.text
                : "Player";
            
            GlobalData.PlayerCount++;
        }
    }
}