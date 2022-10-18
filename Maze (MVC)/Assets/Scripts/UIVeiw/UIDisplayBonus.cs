using System;
using UnityEngine.UI;

namespace Maze
{
    public class UIDisplayBonus
    {
        public Text _pointsLabel;

        public UIDisplayBonus(Text pointsLabel)
        {
            _pointsLabel = pointsLabel;
            _pointsLabel.text = String.Empty;
        }

        public void DisplayBonus(int value)
        {
            _pointsLabel.text = $"{value}";
        }
    }
}