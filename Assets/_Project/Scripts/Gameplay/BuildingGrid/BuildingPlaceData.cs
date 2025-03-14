using System;
using System.Collections.Generic;
using Assets._Project.Scripts.Gameplay.Building;
using UnityEngine;

namespace Assets._Project.Scripts.Gameplay.ItemGrid
{
    //Класс хранящий в себе данные о занимаемых клетках и о предмете
    [Serializable]
    public class BuildingPlaceData
    {
        public List<Vector3> OccupiedPoints;
        public BuildingData BuildingData;

        public BuildingPlaceData()
        {

        }

        public BuildingPlaceData(Vector3 position, BuildingData buildingData)
        {
            OccupiedPoints = new List<Vector3>();
            BuildingData = buildingData;

            for (float x = position.x; x < position.x + BuildingData.ItemSize.x; x += 0.5f)
            {
                for (float y = position.y; y < position.y + BuildingData.ItemSize.y; y += 0.5f)
                {
                    Vector3 coordinate = new Vector3(x, y);

                    if (!OccupiedPoints.Contains(coordinate))
                    {
                        OccupiedPoints.Add(coordinate);
                    }
                }
            }
        }

    }
}