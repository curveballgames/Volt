using UnityEngine;

namespace Volt
{
    [CreateAssetMenu(fileName = "Level Model", menuName = "Volt/Level Model")]
    public class LevelModel : ScriptableObject
    {
        public string LevelName;
        public string SceneName;
        public BuildingIdentifier[] AvailableBuildings;
        public ChallengeModel[] Challenges;
        public LevelCondition[] Conditions;
        public WeatherType[] WeatherConditions;
        public int StartingFunds;
    }
}
