using UnityEngine;

namespace TDS
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour
    {
        #region Public Fields
        public static T Instance { get; private set; }
        #endregion


        #region Protected Methods
        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }
}