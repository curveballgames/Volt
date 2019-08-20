using Curveball;
using TMPro;

namespace Volt
{
    public class FundsPanel : CBGUIComponent
    {
        public TextMeshProUGUI FundsText;

        private void Update()
        {
            string colorStartTag;
            string colorEndTag = "</color>";
            int incomeChange = FundManager.GetCashflow();

            if (incomeChange < 0)
            {
                colorStartTag = "<color=#f88>";
            }
            else if (incomeChange > 0)
            {
                colorStartTag = "<color=#8f8>";
            }
            else
            {
                colorStartTag = "<color=#888>";
            }

            FundsText.text = string.Format("£{0}\t{1}£{2}{3}", FundManager.Funds, colorStartTag, incomeChange, colorEndTag);
        }
    }
}
