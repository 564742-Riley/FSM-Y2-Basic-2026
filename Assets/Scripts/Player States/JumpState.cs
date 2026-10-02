using UnityEngine;

public class JumpState : State
{
    float yvel;
    bool isGrounded;

    public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }




    public override void Enter()
    {
        base.Enter();

        Vector2 moveInput = player.moveAction.ReadValue<Vector2>();

        // Keep horizontal movement when jumping
        player.rb.linearVelocity = new Vector2(
            moveInput.x * 3f,
            5f
        );

        Debug.Log("entering jump state");
        player.anim.SetBool("Jump", true);
        isGrounded = false;
    }



    public override void Exit()
    {
        
        player.anim.SetBool("Jump", false);
    }
    public override void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("player has grounded");
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    public override void Update()
    {
        ReadInput();




        //check for player hitting the ground
        if ( isGrounded)
        {
            sm.ChangeState(sm.idleState);

        }

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }


        UIscript.ui.DrawText("*** This is the jumping state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("left click = Attack State");
    }

    public override void FixedUpdate()
    {
    }
}
