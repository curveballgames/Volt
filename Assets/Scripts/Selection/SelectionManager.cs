using Curveball;
using UnityEngine;

namespace Volt
{
    public class SelectionManager : CBGGameObject
    {
        private static int layerMask;

        private static GameObject highlightedObject;
        private static GameObject selectedObject;

        private void Awake()
        {
            layerMask = Curveball.Utilities.GetCollisionMask("City Building", "Player Building");

            EventSystem.Subscribe<FinishLevelEvent>(OnFinishLevel, this);
            EventSystem.Subscribe<StartConstructionEvent>(OnStartConstruction, this);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<FinishLevelEvent>(OnFinishLevel, this);
            EventSystem.Unsubscribe<StartConstructionEvent>(OnStartConstruction, this);
        }

        private void Update()
        {
            if (LevelStateManager.LevelFinished || LevelStateManager.Paused || BuildManager.IsBuilding)
            {
                return;
            }

            if (Input.GetButtonDown("Cancel Selection") || (selectedObject != null && Input.GetButtonDown("Select")))
            {
                SetSelectedObject(null);
            }

            RaycastHit hitInfo;

            if (!Curveball.Utilities.RaycastMousePosition(out hitInfo, layerMask, InGameCamera.Camera) || UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                SetHighlightedObject(null);
                return;
            }

            SetHighlightedObject(hitInfo.collider.gameObject);

            if (Input.GetButtonDown("Select"))
            {
                SetSelectedObject(highlightedObject);
            }
        }

        void SetHighlightedObject(GameObject hitObject)
        {
            if (highlightedObject == hitObject)
                return;

            highlightedObject = hitObject;
            EventSystem.Publish(new HighlightedBuildingUpdatedEvent(highlightedObject));
        }

        void SetSelectedObject(GameObject hitObject)
        {
            if (hitObject == selectedObject)
                return;

            selectedObject = hitObject;
            EventSystem.Publish(new SelectBuildingEvent(selectedObject));
        }

        void OnFinishLevel(FinishLevelEvent e)
        {
            SetSelectedObject(null);
            SetHighlightedObject(null);
        }

        void OnStartConstruction(StartConstructionEvent e)
        {
            SetHighlightedObject(null);
            SetSelectedObject(null);
        }
    }
}
