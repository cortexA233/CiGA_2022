using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerBaseState : BaseState
{
    protected PlayerController controller;
}


public class PlayerFSM : BaseFSM
{
    public PlayerFSM(PlayerController controller)
    {
        currentState = new IdleState(controller);
    }
    public class IdleState : PlayerBaseState
    {
        public IdleState(PlayerController controller)
        {
            this.controller = controller;
            EnterState();
        }
        public override void EnterState()
        {
            //controller.animator.SetTrigger("isIdle");
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleCollide(Collision2D collision)
        {
            throw new System.NotImplementedException();
        }

        public override void HandleFixedUpdate()
        {
            controller.HandleDirectionInput();
        }

        public override void HandleTrigger(Collider2D collider)
        {
            throw new System.NotImplementedException();
        }

        public override void HandleUpdate()
        {
            controller.HandleJumpInput();
        }
    }

    public class RunState : PlayerBaseState
    {
        public RunState(PlayerController controller)
        {
            this.controller = controller;
            EnterState();
        }
        public override void EnterState()
        {
            //controller.animator.SetTrigger("isIdle");
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public override void HandleCollide(Collision2D collision)
        {
            throw new System.NotImplementedException();
        }

        public override void HandleFixedUpdate()
        {
            controller.HandleDirectionInput();
        }

        public override void HandleTrigger(Collider2D collider)
        {
            throw new System.NotImplementedException();
        }

        public override void HandleUpdate()
        {
            controller.HandleJumpInput();
        }
    }
}
