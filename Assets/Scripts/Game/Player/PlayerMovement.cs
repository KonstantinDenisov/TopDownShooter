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

        #endregion


        #region Unity Lifecycle
        private void Awake()
        {
            _cachedTransform = transform;
            _rb = GetComponent<Rigidbody2D>();
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
            Vector2 direction = _inputService.Axes;
            Vector3 moveDelta = direction * _speed;
            _rb.velocity = moveDelta;
            
            _playerAnimation.SetSpeed(direction.magnitude);
        }

        private void Rotate()
        {
            _cachedTransform.up = _inputService.LookDirection;
        }

        #endregion
        
    }
}