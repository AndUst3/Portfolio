using System;
using UnityEngine.UI;

namespace Maze
{
    public class UIDisplayEndGame
    {
        public Text _endGameLabel;

        public UIDisplayEndGame(Text endGameLabel)
        {
            _endGameLabel = endGameLabel;
            _endGameLabel.text = String.Empty;
        }

        public void EndGame()
        {
            _endGameLabel.text = $"YOU WIN!";
        }
    }
}
