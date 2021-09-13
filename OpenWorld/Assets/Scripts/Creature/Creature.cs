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
        }

        public NInfo.CreatureInfo CreatureInfo { get; private set; }
        public CharacterController CharacterController { get; protected set; }
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
            CharacterController = gameObject.AddComponent<CharacterController>();

            var renderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
            if(renderer == null)
            {
                return;
            }

            if(CharacterController != null)
            {
                CharacterController.center = renderer.bounds.center;
            }

            _model = new Model()
            {
                Renderer = renderer,
            };
        }

        protected abstract void ChainUpdate();
    }
}

