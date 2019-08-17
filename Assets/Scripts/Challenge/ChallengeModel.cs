namespace Volt
{
    [System.Serializable]
    public class ChallengeModel
    {
        public ChallengeType Type;
        public int Target;
        public int Progress;

        public bool Completed
        {
            get => Progress >= Target;
        }

        public bool CompletedPreviously;
    }
}
