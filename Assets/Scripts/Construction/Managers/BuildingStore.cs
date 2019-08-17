using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class BuildingStore : CBGGameObject
    {
        private static BuildingStore singleton;
        private static Dictionary<BuildingIdentifier, PlayerBuildingModel> prefabsByIdentifier;

        public BuildingPrefabDefinition[] PrefabDefinitions;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;

            CreatePrefabDictionary();
        }

        void CreatePrefabDictionary()
        {
            prefabsByIdentifier = new Dictionary<BuildingIdentifier, PlayerBuildingModel>();

            foreach (BuildingPrefabDefinition prefabDefinition in PrefabDefinitions)
            {
                prefabsByIdentifier.Add(prefabDefinition.Identifier, prefabDefinition.Prefab);
            }
        }

        public static PlayerBuildingModel GetBuildingWithIdentifier(BuildingIdentifier identifier)
        {
            return prefabsByIdentifier[identifier];
        }
    }
}
