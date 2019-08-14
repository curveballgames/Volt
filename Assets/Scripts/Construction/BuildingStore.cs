using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class BuildingStore : CBGGameObject
    {
        private static BuildingStore singleton;
        private static Dictionary<BuildingIdentifier, BuildingModel> PrefabsByIdentifier;

        public BuildingPrefabDefinition[] PrefabDefinitions;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;

            CreatePrefabDictionary();
        }

        void CreatePrefabDictionary()
        {
            PrefabsByIdentifier = new Dictionary<BuildingIdentifier, BuildingModel>();

            foreach (BuildingPrefabDefinition prefabDefinition in PrefabDefinitions)
            {
                PrefabsByIdentifier.Add(prefabDefinition.Identifier, prefabDefinition.Prefab);
            }
        }
    }
}
