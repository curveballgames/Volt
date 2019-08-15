using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class BuildingStore : CBGGameObject
    {
        private static BuildingStore singleton;
        private static Dictionary<BuildingIdentifier, BuildingModel> prefabsByIdentifier;

        public BuildingPrefabDefinition[] PrefabDefinitions;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;

            CreatePrefabDictionary();
        }

        void CreatePrefabDictionary()
        {
            prefabsByIdentifier = new Dictionary<BuildingIdentifier, BuildingModel>();

            foreach (BuildingPrefabDefinition prefabDefinition in PrefabDefinitions)
            {
                prefabsByIdentifier.Add(prefabDefinition.Identifier, prefabDefinition.Prefab);
            }
        }

        public static BuildingModel GetBuildingWithIdentifier(BuildingIdentifier identifier)
        {
            return prefabsByIdentifier[identifier];
        }
    }
}
