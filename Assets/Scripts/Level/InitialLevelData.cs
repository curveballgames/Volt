using System.Collections.Generic;

namespace Volt
{
    public class InitialLevelData
    {
        public static List<LevelModel> GetInitialLevelModels()
        {
            return new List<LevelModel>
            {
                new LevelModel("Level 1", "Level 1", new BuildingIdentifier[]{ BuildingIdentifier.SolarPlant, BuildingIdentifier.WindTurbine }, new ChallengeModel[]{}, new LevelCondition[]{}, 500),
                new LevelModel("Level 2", "Level 2", new BuildingIdentifier[]{ BuildingIdentifier.SolarPlant }, new ChallengeModel[]{}, new LevelCondition[]{}, 750)
            };
        }
    }
}
