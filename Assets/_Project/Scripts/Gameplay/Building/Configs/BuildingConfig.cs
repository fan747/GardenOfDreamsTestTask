using System;
using UnityEditor;
using UnityEngine;

namespace Assets._Project.Scripts.Gameplay.Building.Configs
{
    [Serializable]
    public class BuildingConfig
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Vector2 _itemSize;

        [HideInInspector] private BuildingData _data;
        

        public GameObject Prefab => _prefab;

        public Vector2 ItemSize => _itemSize;

        public BuildingData Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new(_itemSize, _prefab.name);
                }

                return _data;
            }
        }

        public Sprite Icon
        {
            get
            {
                if (_icon == null)
                {
                    GenerateIcon();
                }

                return _icon;
            }
        }

        private void GenerateIcon()
        {
            if (_prefab != null)
            {
                Texture2D texture = AssetPreview.GetAssetPreview(_prefab);
            }
        }

    }
}