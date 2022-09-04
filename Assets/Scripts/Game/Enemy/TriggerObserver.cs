﻿using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class TriggerObserver : MonoBehaviour
    {
        #region Ivents
        
        public event Action<Collider2D> OnEntered; 
        public event Action<Collider2D> OnExited; 
        
        #endregion


        #region Private Methods
        
        private void OnTriggerEnter2D(Collider2D col) =>
            OnEntered?.Invoke(col);

        private void OnTriggerExit2D(Collider2D other) =>
            OnExited?.Invoke(other);
        
        #endregion
        
    }
}