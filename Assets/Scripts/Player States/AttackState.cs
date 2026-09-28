using UnityEngine;
public class AttackState : State
{

    protected float speed;
    

    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering Attacking state");

        //player.sr.color = new Color(0.2f, 0.6f, 0.7f);  //change the sprite colour
    }

    public override void Exit()
    {
        //exit the Attack state
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
        
        
        UIscript.ui.DrawText("*** This is the Attacking state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Space = Jump state");

    }
}