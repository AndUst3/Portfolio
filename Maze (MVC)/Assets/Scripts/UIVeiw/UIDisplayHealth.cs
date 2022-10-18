using System;
using UnityEngine.UI;

namespace Maze
{
    public class UIDisplayHealth
    {
        public Text _healthLabel;

        public UIDisplayHealth(Text healthLabel)
        {
            _healthLabel = healthLabel;
            _healthLabel.text = String.Empty;
        }

        public void DisplayHealth(int health)
        {
            _healthLabel.text = $"{health}";
        }
    }
}
