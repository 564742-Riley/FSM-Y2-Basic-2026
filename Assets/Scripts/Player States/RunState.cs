
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

        //player.sr.color = new Color(0.8f, 0.8f, 0.2f);
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("walk", false);
    }



   
    
    public override void Update()
    {
        ReadInput();

        if (player.interactAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }

        
        Vector2 moveInput = player.moveAction.ReadValue<Vector2>();

        // Move player
        player.rb.linearVelocity = moveInput * speed;

        
        if (moveInput.x > 0.1f)
        {
            player.sr.flipX = false;
        }
        else if (moveInput.x < -0.1f)
        {
            player.sr.flipX = true;
        }

        UIscript.ui.DrawText("*** This is the running state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move Sprite");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Space = Jump state");
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
