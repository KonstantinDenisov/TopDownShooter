using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.UI
{
    public class HpPanel: MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _cellPrefab;
        private RectTransform _rectTransform;
        private readonly List<GameObject> _cells = new List<GameObject>();

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            Statistics.Instance.OnHpChanged += HpChanged;
            HpChanged(Statistics.Instance.HPCount);
        }

        private void OnDestroy()
        {
            Statistics.Instance.OnHpChanged -= HpChanged;
        }

        #endregion


        #region Private Methods

        private void HpChanged(int hp)
        {
            int cellsCount = _cells.Count;

            for (int i = 0; i < hp; i++)
            {
                if (cellsCount < hp && cellsCount <= i)
                {
                    GameObject cell = Instantiate(_cellPrefab, _rectTransform);
                    _cells.Add(cell);
                }
            }

            int cellsToRemove = cellsCount - hp;
            if (cellsCount <= 0)
            {
                return;
            }

            for (int i = 0; i < cellsCount; i++)
            {
                int lastIndex = _cells.Count - 1;
                Destroy(_cells[lastIndex]);
                _cells.RemoveAt(lastIndex);
            }
        }

        #endregion
    }
}