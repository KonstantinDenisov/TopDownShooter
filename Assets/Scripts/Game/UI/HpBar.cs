using UnityEngine;
using UnityEngine.UI;

namespace TDS.Game.UI
{
    public class HpBar : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Image _fillImage;

        #endregion


        #region Public Methods

        public void SetFill01(float fillAmount) =>
            _fillImage.fillAmount = fillAmount;

        #endregion
    }
}