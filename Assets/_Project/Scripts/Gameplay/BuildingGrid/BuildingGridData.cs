using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Gameplay.ItemGrid
{
    //Сетка построек - все постройки хранятся тут, + метод определения коллизии
    public class BuildingGridData
    {
        private List<BuildingPlaceData> _itemPlaceDatas = new List<BuildingPlaceData>();

        public BuildingGridData(List<BuildingPlaceData> itemPlaceDatas)
        {
            _itemPlaceDatas = itemPlaceDatas;
        }

        public BuildingGridData()
        {

        }

        public List<BuildingPlaceData> ItemPlaceDatas => _itemPlaceDatas;

        public void AddPlace(BuildingPlaceData buildingPlaceData)
        {
            ItemPlaceDatas.Add(buildingPlaceData);
        }

        public void Replace(Vector3 position)
        {
            _itemPlaceDatas.Remove(ItemPlaceDataOnPosition(position));
        }

        private BuildingPlaceData ItemPlaceDataOnPosition(Vector3 position)
        {
            foreach (var item in _itemPlaceDatas )
            {
                foreach (var vector3 in item.OccupiedPoints)
                {
                    if (position == vector3)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public bool IsOccupied(Vector3 position, Vector2 itemSize)
        {
            List<Vector3> occupiedVector3s = new List<Vector3>();

            for (float x = position.x; x < position.x + itemSize.x; x += 0.5f)
            {
                for (float y = position.y; y < position.y + itemSize.y; y+=0.5f)
                {
                    Vector3 coordinate = new Vector3(x, y);

                    if (!occupiedVector3s.Contains(coordinate))
                    {
                        occupiedVector3s.Add(coordinate);
                    }
                }
            }

            foreach (var occupiedVector3 in occupiedVector3s)
            {
                foreach (var itemPlaceData in ItemPlaceDatas)
                {
                    if (itemPlaceData.OccupiedPoints.Contains(occupiedVector3))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}