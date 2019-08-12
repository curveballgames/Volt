using Curveball;
using TMPro;

namespace Volt
{
    public class LevelPreviewPanel : CBGUIComponent
    {
        public CanvasGroupFader Fader;
        public TextMeshProUGUI Title;
        public LevelPreviewChallengePanel[] ChallengePanels;
        public LevelPreviewModifierPanel[] ModifierPanels;

        private LevelMarker trackedMarker;

        private void Awake()
        {
            EventSystem.Subscribe<LevelMarkerHoverUpdateEvent>(OnLevelMarkerHoverUpdated, this);
        }

        private void LateUpdate()
        {
            if (trackedMarker != null)
            {
                RectTransform.position = OverviewCamera.Camera.WorldToScreenPoint(trackedMarker.transform.position);
            }
        }

        private void OnDestroy()
        {
            trackedMarker = null;
            EventSystem.Unsubscribe<LevelMarkerHoverUpdateEvent>(OnLevelMarkerHoverUpdated, this);
        }

        void OnLevelMarkerHoverUpdated(LevelMarkerHoverUpdateEvent e)
        {
            UpdateContent(e.levelMarker);

            if (e.levelMarker != null)
            {
                trackedMarker = e.levelMarker;
            }

            if (e.levelMarker == null)
            {
                Fader.FadeOut();
            }
            else
            {
                Fader.FadeIn();
            }
        }

        void UpdateContent(LevelMarker marker)
        {
            if (marker == null)
                return;

            LevelModel model = LevelStore.AllLevels[marker.LinkedLevelIndex];
            Title.text = model.LevelName;

            for (int i = 0; i < ChallengePanels.Length; i++)
            {
                ConfigureChallengePanel(i, ref model.Challenges);
            }

            for (int i = 0; i < ModifierPanels.Length; i++)
            {
                ConfigureModifierPanel(i, ref model.Conditions);
            }
        }

        void ConfigureChallengePanel(int index, ref ChallengeModel[] challenges)
        {
            if (index >= challenges.Length)
            {
                ChallengePanels[index].SetActive(false);
            }
            else
            {
                ChallengePanels[index].ChallengeText.text = "TODO: need challenge mappings";
            }
        }

        void ConfigureModifierPanel(int index, ref LevelCondition[] conditions)
        {
            if (index >= conditions.Length)
            {
                ModifierPanels[index].SetActive(false);
            }
            else
            {
                ModifierPanels[index].ModifierDescription.text = "TODO: need modifier mappings";
            }
        }
    }
}
