using System.Collections.Generic;
using Curveball;
using UnityEngine;
using UnityEngine.Events;

namespace Volt
{
    public class Utilities
    {
        public static BuildGridReference GetGridReference(Vector3 location)
        {
            return new BuildGridReference(
                Mathf.FloorToInt(location.x),
                Mathf.FloorToInt(location.z)
            );
        }

        public static BuildGridArea GetArea(BuildGridReference from, int size)
        {
            return GetArea(from.X, from.Z, size);
        }

        public static BuildGridArea GetArea(int fromX, int fromZ, int size)
        {
            BuildGridArea gridArea = new BuildGridArea
            {
                MinX = fromX,
                MaxX = fromX + size - 1,
                MinZ = fromZ,
                MaxZ = fromZ + size - 1
            };

            return gridArea;
        }

        public static List<BuildGridReference> GetGridReferences(int x, int z, int size)
        {
            List<BuildGridReference> gridReferences = new List<BuildGridReference>();

            BuildGridArea gridArea = GetArea(x, z, size);

            for (int ax = gridArea.MinX; ax <= gridArea.MaxX; ax++)
            {
                for (int az = gridArea.MinZ; az <= gridArea.MaxZ; az++)
                {
                    gridReferences.Add(new BuildGridReference(ax, az));
                }
            }

            return gridReferences;
        }

        public static TimerConfig GetInGameTimerConfig()
        {
            return new TimerConfig()
            {
                GetTimerDelta = GetInGameDeltaTime
            };
        }

        public static TimerConfig GetInGameTimerConfig(float timeout, UnityAction onCompleteCallback)
        {
            return new TimerConfig()
            {
                Timeout = timeout,
                OnCompleteCallback = onCompleteCallback,
                GetTimerDelta = GetInGameDeltaTime,
                AutoStart = true
            };
        }

        private static float GetInGameDeltaTime()
        {
            if (LevelStateManager.LevelFinished || LevelStateManager.Paused)
            {
                return 0f;
            }

            return Time.deltaTime;
        }
    }
}
