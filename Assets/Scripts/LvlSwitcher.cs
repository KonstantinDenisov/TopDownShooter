using UnityEngine;

namespace TDS
{
    public class LvlSwitcher : SingletonMonoBehaviour<LvlSwitcher> 
    {
        #region Variables

        [SerializeField] private GameObject _lvl1;
        [SerializeField] private GameObject _lvl2;

        #endregion


        #region Pulic Methods

        public void LoadLvl2()
        {
            _lvl2.gameObject.SetActive(true);
        }

        #endregion
    }
}
