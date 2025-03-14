using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Gameplay.Building.Configs
{
    [CreateAssetMenu(fileName = "BuildingsConfig", menuName = "Configs/new BuildingsConfig")]
    public class BuildingsConfig : ScriptableObject
    {
        [SerializeField] private GameObject _itemIconPrefab;
        [SerializeField] private List<BuildingConfig> _items = new();

        public List<BuildingConfig> Items => _items;

        public GameObject ItemIconPrefab => _itemIconPrefab;
    }
}
