using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCreature
{
    public abstract class Creature
        : MonoBehaviour
    {
        protected struct Model
        {
            public Renderer Renderer { get; set; }
            public Collider Collider { get; set; }
            public Rigidbody Rigidbody { get; set; }
        }

        public NInfo.CreatureInfo CreatureInfo { get; private set; }

        public Vector3 Position { get { return gameObject.transform.position; } }

        protected Model? _model = null;
        protected Animator _animator = null;

        protected virtual void Start()
        {
            InitModel();
        }

        private void Update()
        {
            ChainUpdate();
        }

        void InitModel()
        {
            var renderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
            if(renderer == null)
            {
                return;
            }

            var collider = gameObject.GetComponent<Collider>();
            if (collider == null)
            {
                collider = gameObject.AddComponent<BoxCollider>();
                if (collider == null)
                {
                    return;
                }

                (collider as BoxCollider).center = renderer.bounds.center;
                (collider as BoxCollider).size = renderer.bounds.size;
            }

            var rigidbody = gameObject.AddComponent<Rigidbody>();
            if(rigidbody == null)
            {
                return;
            }

            _model = new Model()
            {
                Renderer = renderer,
                Collider = collider,
                Rigidbody = rigidbody,
            };
        }

        public Rigidbody Rigidbody
        {
            get
            {
                if(_model == null ||
                   _model.HasValue == false)
                {
                    return null;
                }

                return _model.Value.Rigidbody;
            }
        }

        protected abstract void ChainUpdate();
    }
}

