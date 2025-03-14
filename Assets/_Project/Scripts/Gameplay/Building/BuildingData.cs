using System;
using UnityEngine;

namespace Assets._Project.Scripts.Gameplay.Building
{
    [Serializable]
    public class BuildingData
    {
        [SerializeField] private Vector2 _itemSize;
        [SerializeField] private string _prefabId;

        public Vector2 ItemSize => _itemSize;
        public string PrefabId => _prefabId;


        public BuildingData(Vector2 itemSize, string prefabId)
        {
            _itemSize = itemSize;
            _prefabId = prefabId;
        }
    }
}