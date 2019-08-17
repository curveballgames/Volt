﻿using System;
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

        private static LevelStore singleton;

        public LevelModel[] AllLevels;
        public static int CurrentLevelIndex { get; private set; }
        public static LevelModel CurrentLevel { get => singleton.AllLevels[CurrentLevelIndex]; }

        public bool AlwaysCreateNewSaveData = true;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;

            EventSystem.Subscribe<LoadGameDataEvent>(OnLoadGameData, this);
            EventSystem.Subscribe<LoadLevelEvent>(OnLoadLevel, this);
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

        void OnLoadLevel(LoadLevelEvent e)
        {
            CurrentLevelIndex = e.LevelIndex;
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
                AllLevels = JsonConvert.DeserializeObject<LevelModel[]>(allData);
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

        public static LevelModel GetLevel(int index)
        {
            return singleton.AllLevels[index];
        }
    }
}