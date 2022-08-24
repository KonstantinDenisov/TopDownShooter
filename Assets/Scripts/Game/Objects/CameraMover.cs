using UnityEngine;

namespace TDS.Game.Objects
{
    public class CameraMover : MonoBehaviour
    {
        #region Variables
        
        [SerializeField] private Transform _follow;
        private Transform _cachedTransform;
        
        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void LateUpdate()
        {
            Vector3 followPosition = _follow.position;
            followPosition.z = _cachedTransform.position.z;
            _cachedTransform.position = followPosition;
        }

        #endregion

       
    }
}