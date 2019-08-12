namespace Volt
{
    [System.Serializable]
    public class LevelModel
    {
        public string LevelName;
        public string SceneName;
        public ChallengeModel[] Challenges;
        public LevelCondition[] Conditions;

        public LevelModel(string levelName, string sceneName, ChallengeModel[] challenges, LevelCondition[] conditions)
        {
            LevelName = levelName;
            SceneName = sceneName;
            Challenges = challenges;
            Conditions = conditions;
        }

        // TODO: available buildings
    }
}
