using TDS.Game.InputService;
using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed;
        [SerializeField] private PlayerAnimation _playerAnimation;
        private Transform _cachedTransform;
        private Rigidbody2D _rb;
        private IInputService _inputService;
        private Camera _mainCamera;

        #endregion


        #region Unity Lifecycle
        private void Awake()
        {
            _cachedTransform = transform;
            _rb = GetComponent<Rigidbody2D>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Move();
            Rotate();
        }
        #endregion


        #region Public Methods

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        #endregion


        #region Private Methods

        private void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical);
            Vector3 moveDelta = direction * _speed;
            
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
        /*
        private void Move()
        {
            Vector2 direction = _inputService.Axes;
            Vector3 moveDelta = direction * _speed;
            _rb.velocity = moveDelta;

            _playerAnimation.SetSpeed(direction.magnitude);
        }

        private void Rotate()
        {
            _cachedTransform.up = _inputService.LookDirection;
        }
*/
        #endregion
        
    }
}