using UnityEngine;

namespace Logic
{
    public class KeepInCameraBounderies : MonoBehaviour
    {
        private Camera _camera;
        private Vector2 _screenBounds;
        private float _objectWidth;
        private float _objectHeight;

        private void Awake() =>
            _camera = Camera.main;

        private void Start()
        {
            _screenBounds =
                _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));
            _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
            _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        }

        private void LateUpdate()
        {
            Vector3 viewPosition = transform.position;
            viewPosition.x = Mathf.Clamp(viewPosition.x, _screenBounds.x * -1 + _objectWidth,
                _screenBounds.x - _objectWidth);
            viewPosition.y = Mathf.Clamp(viewPosition.y, _screenBounds.y * -1 + _objectHeight,
                _screenBounds.y - _objectHeight);
            transform.position = viewPosition;
        }
    }
}