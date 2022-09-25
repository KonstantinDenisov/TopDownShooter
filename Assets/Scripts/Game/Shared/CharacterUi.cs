using TDS.Game.Objects;
using TDS.Game.UI;
using UnityEngine;

namespace TDS.Game
{
    public class CharacterUi : MonoBehaviour
    {
        #region Variables

        [SerializeField] private HpBar _hpBar;

        private IHealth _health;

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            Construct(GetComponentInChildren<IHealth>());
        }

        private void OnDestroy()
        {
            if (_health != null)
            {
                _health.OnChanged -= HpChanged;
            }
        }

        #endregion


        #region Public Methods

        public void Construct(IHealth health)
        {
            _health = health;

            if (_health != null)
            {
                _health.OnChanged += HpChanged;
                HpChanged(_health.CurrentHp);
            }
        }

        #endregion


        #region Private Methods

        private void HpChanged(int currentHp)
        {
            float fillAmount = currentHp / (float)_health.MaxHp;
            _hpBar.SetFill01(fillAmount);
        }

        #endregion
    }
}