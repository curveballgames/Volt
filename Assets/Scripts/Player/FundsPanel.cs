using Curveball;
using TMPro;

namespace Volt
{
    public class FundsPanel : CBGUIComponent
    {
        public TextMeshProUGUI FundsText;

        private void Update()
        {
            string colorStartTag = "<color=#8f8>";
            string colorEndTag = "</color>";
            string incomeChange = "+TODO";

            FundsText.text = string.Format("{0}\t{1}{2}{3}", FundManager.Funds, colorStartTag, incomeChange, colorEndTag);
        }
    }
}
