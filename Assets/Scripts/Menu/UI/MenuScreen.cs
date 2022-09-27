using TDS.Infrastructure;
using TDS.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Menu.UI
{
    public class MenuScreen : MonoBehaviour
    {
        #region MyRegion

        [SerializeField] private Button _playButton;

        private IGameStateMachine _stateMachine;

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void Start()
        {
            _stateMachine = Services.Container.Get<IGameStateMachine>();
        }

        #endregion


        #region Privete Methods

        private void OnPlayButtonClicked()
        {
            _stateMachine.Enter<GameState>();
        }

        #endregion
    }
}