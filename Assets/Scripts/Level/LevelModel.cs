namespace Volt
{
    [System.Serializable]
    public class LevelModel
    {
        public string LevelName;
        public ChallengeModel[] Challenges;
        public LevelCondition[] Conditions;

        public LevelModel(string levelName, ChallengeModel[] challenges, LevelCondition[] conditions)
        {
            LevelName = levelName;
            Challenges = challenges;
            Conditions = conditions;
        }

        // TODO: available buildings
        // TODO: scene name/ prefab
    }
}
