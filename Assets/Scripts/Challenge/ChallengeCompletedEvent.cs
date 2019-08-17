using Curveball;

namespace Volt
{
    public struct ChallengeCompletedEvent : IEvent
    {
        public ChallengeModel Model;

        public ChallengeCompletedEvent(ChallengeModel model)
        {
            Model = model;
        }
    }
}