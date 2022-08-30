using System;
using System.Collections;
using TDS.Game.Administration;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHpController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _playerAnimation;

        #endregion
        
        #region Unity Life Cycle

        private void Awake()
        {
            throw new NotImplementedException();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("PlayerBullet"))
            {
                Statistics.Instance.DecrementHp();
                CheckDeath();
            }
        }

        #endregion


        #region Private Methods

        private void CheckDeath()
        {
            if (Statistics.Instance.HPCount == 0)
            {
                _playerAnimation.PlayDeath(true);
                StartCoroutine(ReloadSceneRoutine());
            }
            else
            {
                return;
            }
        }
        
        private IEnumerator ReloadSceneRoutine()
        {
            yield return new WaitForSeconds(4);
            SceneLoader.Instance.ReloadScene();
        }

        #endregion
    }
}