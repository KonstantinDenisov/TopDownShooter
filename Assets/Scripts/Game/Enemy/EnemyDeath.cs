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

        [SerializeField] private PickUpInfo[] _pickUpInfoArray;
        [SerializeField] private float _pickUpSpawnChance;
        [SerializeField] private float _firstCoordinateRange;
        [SerializeField] private float _secondCoordinateRange;

        #endregion


        #region Events

        public event Action OnEnemyDead;

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
            if (hp > 0)
            {
                return;
            }
            
            _enemyMeleeAnimation.PlayDeath();
            _enemyMovement.enabled = false;
            OnEnemyDead?.Invoke();
            SpawnItems();
            LoadNextLevel();
        }

        private void SpawnItems()
        {
            if (_pickUpInfoArray == null || _pickUpInfoArray.Length == 0)
                return;

            float random = Random.Range(0f, 1f);
            if (random > _pickUpSpawnChance)
                return;

            int chanceSum = 0;

            foreach (PickUpInfo itemInfo in _pickUpInfoArray)
            {
                chanceSum += itemInfo.SpawnChance;
            }

            int randomChance = Random.Range(0, chanceSum);
            int currentChance = 0;
            int currentIndex = 0;

            for (int i = 0; i < _pickUpInfoArray.Length; i++)
            {
                PickUpInfo pickUpInfo = _pickUpInfoArray[i];
                currentChance += pickUpInfo.SpawnChance;

                if (currentChance >= randomChance)
                {
                    currentIndex = i;
                    break;
                }
            }

            PickUpBase initItem = _pickUpInfoArray[currentIndex].PickUpPrefab;
            
            Vector3 position = new Vector3(Random.Range(_firstCoordinateRange, _secondCoordinateRange),
                transform.position.y, transform.position.z);
            PickUpBase item = Instantiate(initItem, position, Quaternion.identity);
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