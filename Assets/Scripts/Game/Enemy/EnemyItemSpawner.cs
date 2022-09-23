using System;
using System.Collections;
using TDS.Game.PickUp;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDS.Game.Enemy
{
    public class EnemyItemSpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PickUpInfo[] _pickUpInfoArray;
        [SerializeField] private float _pickUpSpawnChance;
        [SerializeField] private float _radiusSpawn;

        #endregion
        
        public void SpawnItems()
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

            Vector3 localSpawnPosition = Random.insideUnitCircle * _radiusSpawn;
            Vector3 worldSpawnPosition = transform.TransformPoint(localSpawnPosition);
            
            Instantiate(initItem, worldSpawnPosition, Quaternion.identity);
        }
    }
}