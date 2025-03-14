using System.Collections.Generic;
using System.IO;
using Assets._Project.Scripts.Gameplay.ItemGrid;
using UnityEngine;

namespace Assets._Project.Scripts.Gameplay.SaveSystem
{
    public class SaveSystem 
    {
        private readonly string _savePath;

        public SaveSystem()
        {
            _savePath = Path.Combine(Application.persistentDataPath, "game_save.json");
        }

        public void SaveGame(List<BuildingPlaceData> items)
        {
            Debug.Log($"Saved into: {_savePath}");
            GameSaveData saveData = new GameSaveData();
            saveData.placedItems = items;
            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(_savePath, json);
        }

        public List<BuildingPlaceData> LoadGame()
        {
            if (File.Exists(_savePath))
            {
                string json = File.ReadAllText(_savePath);
                GameSaveData saveData = JsonUtility.FromJson<GameSaveData>(json);
                return saveData.placedItems;
            }
            return new List<BuildingPlaceData>();
        }
    }
}