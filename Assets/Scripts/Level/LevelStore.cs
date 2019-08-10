using System;
using System.Collections.Generic;
using System.IO;
using Curveball;
using Newtonsoft.Json;
using UnityEngine;

namespace Volt
{
    public class LevelStore : CBGGameObject
    {
        private static readonly string SAVE_DATA_PATH = "/ld.lvldt";
        private static string saveDataPath
        {
            get
            {
                return Application.persistentDataPath + SAVE_DATA_PATH;
            }
        }

        public static List<LevelModel> AllLevels { get; private set; }

        public bool AlwaysCreateNewSaveData = true;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            EventSystem.Subscribe<LoadGameDataEvent>(OnLoadGameData, this);
        }

        void OnLoadGameData(LoadGameDataEvent e)
        {
            LoadLevelData();

            Timer.CreateTimer(gameObject, 0.01f, () =>
            {
                EventSystem.Unsubscribe<LoadGameDataEvent>(OnLoadGameData, this);
                EventSystem.Publish(new GameDataLoadedEvent());
            });
        }

        void LoadLevelData()
        {
            if (Application.isEditor && AlwaysCreateNewSaveData)
            {
                CreateInitialSaveData();
                return;
            }

            try
            {
                string allData = File.ReadAllText(saveDataPath);
                AllLevels = JsonConvert.DeserializeObject<List<LevelModel>>(allData);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                Debug.Log("Could not find level data at " + saveDataPath + ". Creating new level data.");

                CreateInitialSaveData();
            }
        }

        void CreateInitialSaveData()
        {
            AllLevels = InitialLevelData.GetInitialLevelModels();
            SaveLevelData();
        }

        void SaveLevelData()
        {
            try
            {
                string allData = JsonConvert.SerializeObject(AllLevels);
                File.WriteAllText(saveDataPath, allData);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
