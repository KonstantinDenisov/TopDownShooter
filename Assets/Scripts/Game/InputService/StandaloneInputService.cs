using UnityEngine;

namespace TDS.Game.InputService
{
    public class StandaloneInputService : IInputService
    {
        #region Variables

        private readonly Camera _mainCamera;
        private readonly Transform _playerMovementTransform;

        #endregion


        #region Propertis

        public Vector2 Axes => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        public Vector3 LookDirection => GetLookDirection();

        #endregion


        #region Public Methods

        public StandaloneInputService(Camera camera, Transform playerMovementTransform)
        {
            _mainCamera = camera;
            _playerMovementTransform = playerMovementTransform;
        }

        #endregion


        #region Private Methods

        private Vector3 GetLookDirection()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0f;

            return worldPoint - _playerMovementTransform.position;
        }

        #endregion
    }
}