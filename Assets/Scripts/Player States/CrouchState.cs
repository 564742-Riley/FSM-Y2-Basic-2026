using UnityEngine;
using UnityEngine.InputSystem;

public class CrouchState : State
{
   
     public CrouchState(PlayerScript player, StateMachine sm) : base(player, sm)
     {
     }

    public override void Enter()
    {
        Debug.Log("entering the crouch state");
        player.anim.SetBool("Crouch", true);

    }


    public override void Exit()
    {
        //exit the Crouch state
        player.anim.SetBool("Crouch", false);
    }
    public override void Update()
    {
        if (Keyboard.current.cKey.wasReleasedThisFrame)
        {
            sm.ChangeState(sm.idleState);
           
        }

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }

        if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f)
        {
            sm.ChangeState(sm.runState);
        }

       

        UIscript.ui.DrawText("*** This is the Crouching state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move Sprite");
        UIscript.ui.DrawText("Space = Jump state");
        UIscript.ui.DrawText("left click = Attack State");

    }

}
