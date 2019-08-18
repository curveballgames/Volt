using UnityEngine;

namespace Volt
{
    public class CachedCalculator
    {
        public delegate int Calculate();

        private int lastCalculation;
        private int lastCalculationFrame;
        private readonly Calculate recalculate;

        public CachedCalculator(Calculate calculationFunction)
        {
            recalculate = calculationFunction;
        }

        public int GetCalculation()
        {
            if (lastCalculationFrame < Time.frameCount)
            {
                lastCalculation = recalculate();
                lastCalculationFrame = Time.frameCount;
            }

            return lastCalculation;
        }
    }
}
