using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed;
        [SerializeField] private PlayerAnimation _playerAnimation;
        private Transform _cachedTransform;
        private Camera _mainCamera;

        #endregion


        #region Unity Lifecycle
        private void Awake()
        {
            _cachedTransform = transform;
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Move();
            Rotate();
        }
        #endregion


        #region Private Methods

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            Vector2 direction = new Vector2(horizontal, vertical);
            Vector3 moveDelta = direction * (_speed * Time.deltaTime);
            _cachedTransform.position += moveDelta;
            
            _playerAnimation.SetSpeed(direction.magnitude);
        }

        private void Rotate()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0f;

            Vector3 direction = worldPoint - _cachedTransform.position;
            _cachedTransform.up = direction;
        }

        #endregion
        
    }
}