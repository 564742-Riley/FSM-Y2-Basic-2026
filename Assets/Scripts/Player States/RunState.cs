
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class RunState : State
{
    protected float speed;
    protected float rotationSpeed;

    public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        speed = 3;
        base.Enter();
        horizontalInput = verticalInput = 0.0f;

        Debug.Log("entering running state");
        player.anim.SetBool("walk", true);

       
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("walk", false);
    }





    public override void Update()
    {
        ReadInput();

        Vector2 moveInput = player.moveAction.ReadValue<Vector2>();

       
        if (player.jumpAction.WasPressedThisFrame())
        {
            
            player.rb.linearVelocity = new Vector2(
                moveInput.x * speed,
                player.rb.linearVelocity.y
            );

            sm.ChangeState(sm.jumpState);
            
        }

        // Attack
        if (player.attackAction.WasPressedThisFrame())
        {
            sm.ChangeState(sm.attackState);
            
        }

        
        if (moveInput.magnitude < 0.1f)
        {
            sm.ChangeState(sm.idleState);
            
        }

       
        player.rb.linearVelocity = new Vector2(
            moveInput.x * speed,
            player.rb.linearVelocity.y
        );

        if (moveInput.x > 0.1f)
        {
            player.sr.flipX = false;
        }
        else if (moveInput.x < -0.1f)
        {
            player.sr.flipX = true;
        }

        UIscript.ui.DrawText("*** This is the running state ***\n");
        UIscript.ui.DrawText("Space = Jump State");
        UIscript.ui.DrawText("left click = Attack State");
    }


    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided in runstate");

        if( collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }
    public override void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collision in runstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        }
    }



    public override void FixedUpdate()
    {
    }
}
