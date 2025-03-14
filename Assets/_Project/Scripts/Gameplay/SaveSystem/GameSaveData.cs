using System.Collections.Generic;
using Assets._Project.Scripts.Gameplay.ItemGrid;

namespace Assets._Project.Scripts.Gameplay.SaveSystem
{
    [System.Serializable]
    public class GameSaveData
    {
        public List<BuildingPlaceData> placedItems = new List<BuildingPlaceData>();
    }
}