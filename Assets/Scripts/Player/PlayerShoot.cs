using System;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using Mirror;
using Projectiles;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerShoot : NetworkBehaviour
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private Transform _fireTransform;
        [SerializeField] private Bullet _bulletPrefab;

        private IInputService _inputService;
        private static int _layerMask;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _layerMask = 1 << LayerMask.NameToLayer("Player");
        }

        private void Update()
        {
            if (!isLocalPlayer) 
                return;
            
            if (_inputService.IsAttackButtonUp()) 
                CmdShoot();
        }

        [Command]
        private void CmdShoot() => 
            Shoot();

        [ClientRpc]
        private void Shoot()
        {
            Vector2 origin = _fireTransform.position;
            float direction = transform.lossyScale.x < 0f ? -1f : 1f;
            
            var bulletDirection = new Vector2(direction, 0);

            SpawnBullet(origin, bulletDirection);
            
            PlayShootAnimation();
        }

        private void PlayShootAnimation()
        {
            _playerAnimator.PlayShoot();
        }

        private void SpawnBullet(Vector2 position, Vector2 direction)
        {
            Bullet bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
            bullet.Initialize(direction, _layerMask);
        }
    }
}