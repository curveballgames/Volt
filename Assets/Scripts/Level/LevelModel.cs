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

        public LevelModel(string levelName, string sceneName, BuildingIdentifier[] availableBuildings, ChallengeModel[] challenges, LevelCondition[] conditions)
        {
            LevelName = levelName;
            SceneName = sceneName;
            AvailableBuildings = availableBuildings;
            Challenges = challenges;
            Conditions = conditions;
        }
    }
}
