using System.Collections.Generic;

namespace Volt
{
    public class InitialLevelData
    {
        public static List<LevelModel> GetInitialLevelModels()
        {
            return new List<LevelModel>
            {
                new LevelModel("Level 1", "Level 1", new ChallengeModel[]{}, new LevelCondition[]{}),
                new LevelModel("Level 2", "Level 2", new ChallengeModel[]{}, new LevelCondition[]{})
            };
        }
    }
}
