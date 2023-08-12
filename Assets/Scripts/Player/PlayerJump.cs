using Infrastructure.Services;
using Infrastructure.Services.Input;
using Logic;
using Mirror;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimator))]
    public class PlayerJump : NetworkBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private ColliderCheck _groundCheck;

        private IInputService _inputService;

        private void Awake() => 
            _inputService = AllServices.Container.Single<IInputService>();
        
        private void Update()
        {
            if (!isLocalPlayer)
                return;
            
            if (_groundCheck.IsTouchingLayer && _inputService.IsJumpButtonUp())
            {
                CmdJump();
            }
        }

        [Command]
        private void CmdJump() => 
            Jump();

        [ClientRpc]
        private void Jump()
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            _animator.PlayJump();
        }
    }
}