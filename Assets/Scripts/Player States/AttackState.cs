using UnityEngine;
using UnityEngine.InputSystem;
public class AttackState : State
{

    protected float speed;
    

    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering Attacking state");

       

        //play the Attack animation
        player.anim.SetBool("Attack", true);



    }

    public override void Exit()
    {
        //exit the Attack state
        player.anim.SetBool("Attack", false);
    }
    public override void Update()
    {
        ReadInput();

        if (player.interactAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);

        }
        if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f)
        {
            sm.ChangeState(sm.runState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }
        
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            sm.ChangeState(sm.idleState);
        }


        UIscript.ui.DrawText("*** This is the Attacking state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("C = Crouch");
        UIscript.ui.DrawText("Space = Jump state");

    }
}