using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Maze
{
    public abstract class Bonus : IExecute, IFlick, IFly, IRotation
    {
        private Transform _transform;
        private Collider _collider;
        private Renderer _renderer;
        private Material _material;
        protected Color _color;
        public Renderer Renderer { get => _renderer; set => _renderer = value; }

        private bool _isInteractable;
        public float heightFly;
        public float speedRotation;

        protected ObjectView _view;

        public Bonus(ObjectView view)
        {
            _view = view;
            _transform = _view._Transform;
            _collider = _view._Collider;
            _renderer = _view._Renderer;
            _color = Random.ColorHSV();
            _renderer.sharedMaterial.color = _color;
            IsInteractable = true;
        }

        public virtual void Init()
        {
            heightFly = Random.Range(1f, 5f);
            speedRotation = Random.Range(10f, 50f);
            _material = _view._Renderer.material;
        }

        public void Update()
        {
            Fly();
            Flick();
            Rotate();
        }

        public void Fly()
        {
            _view._Transform.position = new Vector3(_view._Transform.position.x, Mathf.PingPong(Time.time, heightFly), _view._Transform.position.z);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        public void Rotate()
        {
            _view._Transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);
        }

        public bool IsInteractable 
        { 
            get => _isInteractable; 
            set
            {
                _isInteractable = value;
                _renderer.enabled = value;
                _collider.enabled = value;
            }  
        }

        protected abstract void Interaction();
    }
}