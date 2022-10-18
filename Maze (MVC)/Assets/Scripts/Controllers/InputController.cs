using UnityEngine;

namespace Maze
{
    public class InputController : IExecute
    {
        private readonly Unit _player;

        private float _horizontal;
        private float _vertical;
        private float _jumpForce = 200;

        public InputController(Unit player)
        {
            _player = player;
        }

        public void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            _player.Move(_horizontal, 0, _vertical);

            _player.Jump(0, _jumpForce, 0);
        }
    }
}