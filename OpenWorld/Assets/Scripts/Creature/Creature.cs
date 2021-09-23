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
            public Rigidbody Rigidbody { get; set; }
            public BoxCollider BoxCollider { get; set; }
        }

        public NInfo.CreatureInfo CreatureInfo { get; private set; }
        public Animator Animator { get; protected set; }

        public Vector3 Position { get { return gameObject.transform.position; } }
        
        protected Model? _model = null;        

        protected virtual void Start()
        {
            Animator = gameObject.GetComponent<Animator>();

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

            var rigidbody = gameObject.AddComponent<Rigidbody>();
            if (!rigidbody)
            {
                return;
            }

            var boxCollider = gameObject.AddComponent<BoxCollider>();
            if (!boxCollider)
            {
                return;
            }

            boxCollider.center = renderer.bounds.center;
            boxCollider.size = renderer.bounds.size;

            _model = new Model()
            {
                Renderer = renderer,
                Rigidbody = rigidbody,
                BoxCollider = boxCollider,
            };
        }

        protected abstract void ChainUpdate();
    }
}

