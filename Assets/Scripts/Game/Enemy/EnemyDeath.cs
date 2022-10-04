using System;
using System.Collections;
using TDS.Game.PickUp;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        public event Action<EnemyDeath> OnHappened;
       
    }
}