using UnityEngine.SceneManagement;

namespace TDS
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        #region Public Methods

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void LoadNextLevel()
        {
        
        }

        #endregion
    }
}