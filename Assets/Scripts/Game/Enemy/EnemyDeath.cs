using System;
using System.Collections;
using TDS.Game.PickUp;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyMeleeAnimation _enemyMeleeAnimation;
        [SerializeField] private EnemyAttackAgro _enemyAttackAgro;
        [SerializeField] private EnemyItemSpawner _enemyItemSpawner;

        private bool _isDeath;

        #endregion

        #region Unity Lifecicle

        private void OnEnable()
        {
            _enemyHp.OnDecrementHp += CheckDeath;
        }

        private void OnDisable()
        {
            _enemyHp.OnDecrementHp -= CheckDeath;
        }

        #endregion


        #region Private Methods

        private void CheckDeath(int hp)
        {
            if (hp > 0 || _isDeath)
            {
                return;
            }

            _enemyMeleeAnimation.PlayDeath();
            _enemyMovement.enabled = false;
            _enemyAttackAgro.enabled = false;
            _enemyItemSpawner.SpawnItems();
            LoadNextLevel();
            _isDeath = true;
        }

        private void LoadNextLevel()
        {
            StartCoroutine(LoadNextLevelEnumerator());
        }

        IEnumerator LoadNextLevelEnumerator()
        {
            yield return new WaitForSeconds(1f);
            //SceneLoader.Instance.LoadNextLevel();
            LvlSwitcher.Instance.LoadLvl2();
        }

        #endregion
       
    }
}