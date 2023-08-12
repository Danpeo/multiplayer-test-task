using Infrastructure.Services;
using Infrastructure.Services.Input;
using Mirror;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimator))]
    public class PlayerLocomotion : NetworkBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _moveSpeed = 10.0f;
        [SerializeField] private PlayerAnimator _animator;

        private Camera _camera;
        private IInputService _inputService;

        private void Awake() => 
            _inputService = AllServices.Container.Single<IInputService>();

        private void Start() =>
            _camera = Camera.main;

        private void FixedUpdate()
        {
            if (!isLocalPlayer)
                return;
            
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > float.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.Normalize();
                DeterminePlayerOrientation();
                _animator.Move();
            }
            else
            {
                _animator.StopMoving();
            }

            float xVelocity = movementVector.x * _moveSpeed;
            _rigidBody.velocity = new Vector2(xVelocity, _rigidBody.velocity.y);
        }

        private void DeterminePlayerOrientation()
        {
            float xScale = Mathf.Abs(transform.localScale.x) * Mathf.Sign(_rigidBody.velocity.x);
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
    }
}