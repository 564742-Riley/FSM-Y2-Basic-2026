using UnityEngine;

public class JumpState : State
{
    float yvel;

    public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering Jumping state");

        // Jump strength
        yvel = 5f;

        // Apply the jump velocity
        player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x,yvel );
           
        // Play jump animation
        player.anim.SetBool("Jump", true);
    }

    public override void Exit()
    {
        player.anim.SetBool("Jump", false);
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

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }

        UIscript.ui.DrawText("*** This is the jumping state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("left click = Attack State");
    }

    public override void FixedUpdate()
    {
        
    }
}
