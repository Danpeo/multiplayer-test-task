using UnityEngine;

namespace Logic
{
    public class ColliderCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;
        [SerializeField] private Collider2D _collider;
        public bool IsTouchingLayer;
        
        private void Awake() => 
            _collider = GetComponent<Collider2D>();

        private void OnTriggerStay2D(Collider2D other) => 
            IsTouchingLayer = _collider.IsTouchingLayers(_layer);

        private void OnTriggerExit2D(Collider2D other) => 
            IsTouchingLayer = _collider.IsTouchingLayers(_layer);
    }
}