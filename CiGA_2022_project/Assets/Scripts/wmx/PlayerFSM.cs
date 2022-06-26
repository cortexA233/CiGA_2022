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

    public void TransitState(PlayerBaseState newState)
    {
        currentState.ExitState();
        currentState = null;
        currentState = newState;
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
            controller.ClearHook();
            controller.ropeObj.transform.localScale = new Vector2(1, 1);
            controller.hookObj.transform.localScale = new Vector2(1, 1);
        }

        public override void ExitState()
        {
            //throw new System.NotImplementedException();
        }

        public override void HandleCollide(Collision2D collision)
        {
            throw new System.NotImplementedException();
        }

        public override void HandleFixedUpdate()
        {

        }

        public override void HandleTrigger(Collider2D collider)
        {

        }

        public override void HandleUpdate()
        {
            //Debug.Log("Idle");
            controller.HandleHorizantalInput();
            controller.HandleThrowBaitInput();
            controller.FollowMousePosition();
            if (Input.GetMouseButtonDown(0))
            {
                controller.stateMachine.TransitState(new ShootState(controller));
            }
        }
    }

    public class ShootState : PlayerBaseState
    {
        public ShootState(PlayerController controller)
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

        }

        public override void HandleCollide(Collision2D collision)
        {
            throw new System.NotImplementedException();
        }

        public override void HandleFixedUpdate()
        {

        }

        public override void HandleTrigger(Collider2D collider)
        {
            //Debug.Log("!!!");
        }

        public override void HandleUpdate()
        {
            //Debug.Log("Shoot");
            controller.ropeObj.transform.localScale = new Vector2(controller.ropeObj.transform.localScale.x, controller.ropeObj.transform.localScale.y + controller.hookSpeed * Time.deltaTime);
            controller.hookObj.transform.localScale = new Vector2(controller.hookObj.transform.localScale.x, 1f / controller.ropeObj.transform.localScale.y);
            if (controller.ropeObj.transform.localScale.y > 111f)
            {
                controller.stateMachine.TransitState(new BackState(controller));
            }
            if (controller.CheckHookHasCaught() == true || controller.CheckHookCollideFish() == true)
            {
                //Debug.Log("!");
                controller.stateMachine.TransitState(new BackState(controller));
            }
        }
    }

    public class BackState : PlayerBaseState
    {
        public BackState(PlayerController controller)
        {
            this.controller = controller;
            EnterState();
        }
        public override void EnterState()
        {

        }

        public override void ExitState()
        {

        }

        public override void HandleCollide(Collision2D collision)
        {
            throw new System.NotImplementedException();
        }

        public override void HandleFixedUpdate()
        {

        }

        public override void HandleTrigger(Collider2D collider)
        {

        }

        public override void HandleUpdate()
        {
            //Debug.Log("Back");
            controller.ropeObj.transform.localScale = new Vector2(controller.ropeObj.transform.localScale.x, controller.ropeObj.transform.localScale.y - controller.hookSpeed * Time.deltaTime);
            controller.hookObj.transform.localScale = new Vector2(controller.hookObj.transform.localScale.x, 1f / controller.ropeObj.transform.localScale.y);
            if (controller.ropeObj.transform.localScale.y < 1f)
            {
                controller.stateMachine.TransitState(new IdleState(controller));
            }
        }
    }
}
