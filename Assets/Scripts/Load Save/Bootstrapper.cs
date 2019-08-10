using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Curveball;
using UnityEngine.SceneManagement;

namespace Volt
{
    public class Bootstrapper : CBGGameObject
    {
        private AsyncOperation sceneLoadOperation = null;

        private void Awake()
        {
            EventSystem.Subscribe<GameDataLoadedEvent>(OnGameDataLoaded, this);
        }

        private void Start()
        {
            EventSystem.Publish(new LoadGameDataEvent());
        }

        private void Update()
        {
            if (sceneLoadOperation != null && sceneLoadOperation.isDone)
            {
                EventSystem.Unsubscribe<GameDataLoadedEvent>(OnGameDataLoaded, this);
                SceneManager.UnloadSceneAsync("Core Scene");
                DestroyImmediate(gameObject);
            }
        }

        void OnGameDataLoaded(GameDataLoadedEvent e)
        {
            sceneLoadOperation = SceneManager.LoadSceneAsync("Overworld Scene", LoadSceneMode.Additive);
        }
    }
}
