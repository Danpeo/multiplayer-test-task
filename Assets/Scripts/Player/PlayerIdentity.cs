using System;
using Infrastructure.Services.Network;
using Mirror;

namespace Player
{
    public class PlayerIdentity : NetworkBehaviour
    {
        [SyncVar(hook = nameof(OnNameChanged))]
        private string _name;

        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                NameChanged?.Invoke();
            }
        }

        public event Action NameChanged;

        private void Start()
        {
            if (isLocalPlayer)
                CmdSetName(NetworkService.PlayerName);
        }

        [Command]
        private void CmdSetName(string newName) => 
            ChangeName(newName);

        private void OnNameChanged(string oldName, string newName) => 
            ChangeName(newName);

        private void ChangeName(string newName)
        {
            Name = newName;
            NameChanged?.Invoke();
        }
    }
}