using UnityEngine;

namespace Maze
{
    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;

        public virtual void Awake()
        {
            _transform = GetComponent<Transform>();
            _rb = GetComponent<Rigidbody>();
        }

        public abstract void Move(float x, float y, float z);

        public abstract void Jump(float x, float y, float z);
    }
}