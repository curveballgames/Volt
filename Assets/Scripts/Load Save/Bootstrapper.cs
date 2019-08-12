using Curveball;

namespace Volt
{
    public class Bootstrapper : CBGGameObject
    {
        private void Start()
        {
            EventSystem.Publish(new LoadGameDataEvent());

            Timer.CreateTimer(gameObject, 0.01f, () =>
            {
                DestroyImmediate(gameObject);
            });
        }
    }
}
