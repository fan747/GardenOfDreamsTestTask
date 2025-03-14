using System.Collections.Generic;
using Assets._Project.Scripts.Gameplay.Building;
using UnityEngine;

namespace Assets._Project.Scripts.Gameplay.ItemGrid
{
    //Скрипт для управления предметам на сетке ( добавление и удаление ), + управляет данными BuildingGridData
    public class BuildingGrid
    {
        private Dictionary<GameObject, BuildingPlaceData> _items = new Dictionary<GameObject, BuildingPlaceData>();
        private BuildingGridData _buildingGridData = new();

        public BuildingGrid(BuildingGridData buildingGridData)
        {
            _buildingGridData = buildingGridData;
            Load();
        }

        public BuildingGrid()
        {
        }

        public void Load()
        {
            foreach (var placeData in _buildingGridData.ItemPlaceDatas)
            {
                var prefab = Resources.Load($"Prefabs/{placeData.BuildingData.PrefabId}");
                var gameObject = GameObject.Instantiate(prefab, placeData.OccupiedPoints[0] + new Vector3(placeData.BuildingData.ItemSize.x, placeData.BuildingData.ItemSize.y) / 2, Quaternion.identity);
                _items.Add((GameObject)gameObject, placeData);
            }
        }

        public void Place(GameObject itemPrefab, BuildingData buildingData, Vector3 position)
        {
            if (_buildingGridData.IsOccupied(position, buildingData.ItemSize)) return;

            var gameObject = GameObject.Instantiate(itemPrefab, position + new Vector3( buildingData.ItemSize.x, buildingData.ItemSize.y) / 2, Quaternion.identity);

            BuildingPlaceData place = new(position, buildingData);

            _items.Add(gameObject, place);
            _buildingGridData.AddPlace(place);
        }

        public void Replace(Vector3 position)
        {
            var gameObject = ObjectOnPosition(position);

            if (gameObject == null) return;

            _items.Remove(gameObject);
            GameObject.Destroy(gameObject);

            _buildingGridData.Replace(position);
        }

        private GameObject ObjectOnPosition(Vector3 position)
        {
            foreach (var item in _items)
            {
                foreach (var vector3 in item.Value.OccupiedPoints)
                {
                    if (position == vector3)
                    {
                        return item.Key;
                    }
                }
            }

            return null;
        }
    }
}