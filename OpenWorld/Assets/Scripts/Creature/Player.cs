using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NHandler;

namespace NCreature
{
    public class Player
        : Character
    {
        PlayerInputHandler _playerInputHandler = null;

        protected override void Start()
        {
            base.Start();

            InitPlayerInputHandler();

            //var crafterGameObj = Instantiate(Resources.Load("Prefabs/Crafter")) as GameObject;

            //CraftingAnims.CrafterController craftController = crafterGameObj.GetComponent<CraftingAnims.CrafterController>();
            //crafterGameObj.transform.SetParent(transform);

            //craftController.charState = CraftingAnims.CrafterState.Idle;
        }

        protected override void ChainUpdate()
        { 
            ExecuteCommand();
        }

        void InitPlayerInputHandler()
        {
            _playerInputHandler = new PlayerInputHandler();
        }

        void ExecuteCommand()
        {
            if (_playerInputHandler == null)
            {
                return;
            }

            var command = _playerInputHandler.HandleInput();
            if (command == null)
            {
                return;
            }

            command.Execute(this);
        }
    }
}

