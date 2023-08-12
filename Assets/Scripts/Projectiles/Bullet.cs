using Logic;
using Mirror;
using UnityEngine;

namespace Projectiles
{
    public class Bullet : NetworkBehaviour
    {
        [SerializeField] private float _speed = 15f;
        [SerializeField] private float _damage = 5f;
        private Vector2 _direction;
        private int _layerMask;
        private readonly RaycastHit2D[] _hitBuffer = new RaycastHit2D[10];


        public void Initialize(Vector2 direction, int layerMask)
        {
            _direction = direction.normalized;
            _layerMask = layerMask;
            DetermineBulletOrientation();
        }

        private void Update()
        {
            transform.position += new Vector3(_direction.x * (_speed * Time.deltaTime), 0f, 0f);

            int hitCount = Physics2D.RaycastNonAlloc(transform.position, _direction, _hitBuffer, _speed * Time.deltaTime, _layerMask);

            if (hitCount <= 0)
                return;
            
            for (int i = 0; i < hitCount; i++)
            {
                _hitBuffer[i].collider.gameObject.GetComponent<IHealth>().TakeDamage(_damage);
                
                Destroy(gameObject);
            }
        }
        
        private void DetermineBulletOrientation()
        {
            float xScale = Mathf.Abs(transform.localScale.x) * Mathf.Sign(_direction.x);
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
    }
}
