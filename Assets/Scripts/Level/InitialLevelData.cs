using System.Collections.Generic;

namespace Volt
{
    public class InitialLevelData
    {
        public static List<LevelModel> GetInitialLevelModels()
        {
            return new List<LevelModel>
            {
                new LevelModel("Level 1", new ChallengeModel[]{}, new LevelCondition[]{})
            };
        }
    }
}
