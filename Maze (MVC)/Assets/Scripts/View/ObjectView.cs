using System;
using UnityEngine;

namespace Maze
{
    public enum Type
    {
        good, 
        bad
    }

    public class ObjectView : MonoBehaviour
    {
        public Type type;
        public Action<Player> Collide { get; set; }

        [SerializeField] private Transform _transform;
        [SerializeField] private Collider _collider;
        [SerializeField] private Renderer _renderer;

        public Transform _Transform { get => _transform; set => _transform = value; }
        public Collider _Collider { get => _collider; set => _collider = value; }
        public Renderer _Renderer { get => _renderer; set => _renderer = value; }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player contactView))
            {
                Collide?.Invoke(contactView);
            }  
        }
    }
}