namespace Volt
{
    [System.Serializable]
    public class LevelModel
    {
        public string LevelName;
        public string SceneName;
        public BuildingIdentifier[] AvailableBuildings;
        public ChallengeModel[] Challenges;
        public LevelCondition[] Conditions;
        public int StartingFunds;

        public LevelModel(string levelName, string sceneName, BuildingIdentifier[] availableBuildings, ChallengeModel[] challenges, LevelCondition[] conditions, int startingResources)
        {
            LevelName = levelName;
            SceneName = sceneName;
            AvailableBuildings = availableBuildings;
            Challenges = challenges;
            Conditions = conditions;
            StartingFunds = startingResources;
        }
    }
}
