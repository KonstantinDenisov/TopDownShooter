using System;
using UnityEngine;

namespace TDS.Game.PickUp
{
    [Serializable]
    public class PickUpInfo
    {
        #region Variables

        [HideInInspector]
        public string name;
        public PickUpBase PickUpPrefab;
        public int SpawnChance;

        #endregion


        #region Public Methods

        public void UpdateName()
        {
            name = PickUpPrefab == null ? string.Empty : PickUpPrefab.name;
        }

        #endregion
    }
}