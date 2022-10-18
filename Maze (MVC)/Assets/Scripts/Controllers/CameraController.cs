using UnityEngine;

namespace Maze
{
    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _camera;
        private Vector3 _offset;

        public CameraController(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
            _offset = _camera.position - _player.position;
            _camera.LookAt(_player);
        }

        public void Update()
        {
            _camera.position = _player.position + _offset;
        }
    }
}