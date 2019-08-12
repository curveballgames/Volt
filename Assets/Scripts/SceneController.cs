using System.Collections;
using Curveball;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Volt
{
    public class SceneController : CBGGameObject
    {
        private static AsyncOperation sceneLoadOperation;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            EventSystem.Subscribe<GameDataLoadedEvent>(OnGameDataLoaded, this);
            EventSystem.Subscribe<LoadLevelEvent>(OnLoadLevel, this);
        }

        void OnGameDataLoaded(GameDataLoadedEvent e)
        {
            LoadInitialScene();

            Timer.CreateTimer(gameObject, 0.01f, () =>
            {
                EventSystem.Unsubscribe<GameDataLoadedEvent>(OnGameDataLoaded, this);
            });
        }

        void OnLoadLevel(LoadLevelEvent e)
        {
            LoadCoreLevelScene(e.LevelIndex);
        }

        void LoadInitialScene()
        {
            sceneLoadOperation = SceneManager.LoadSceneAsync("Overworld Scene", LoadSceneMode.Single);
        }

        void LoadCoreLevelScene(int levelIndex)
        {
            sceneLoadOperation = SceneManager.LoadSceneAsync("Core Level Scene", LoadSceneMode.Single);
            StartCoroutine(LoadSpecificLevelScene());
        }

        IEnumerator LoadSpecificLevelScene()
        {
            while (sceneLoadOperation != null && !sceneLoadOperation.isDone)
            {
                yield return null;
            }

            sceneLoadOperation = SceneManager.LoadSceneAsync(LevelStore.CurrentLevel.SceneName, LoadSceneMode.Additive);
            StartCoroutine(PublishLevelLoadedEvent());
        }

        IEnumerator PublishLevelLoadedEvent()
        {
            while (sceneLoadOperation != null && !sceneLoadOperation.isDone)
            {
                yield return null;
            }

            EventSystem.Publish(new LevelLoadedEvent());
        }
    }
}
