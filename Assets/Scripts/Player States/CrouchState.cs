using UnityEngine;

public class CrouchState : State
{
   
     public CrouchState(PlayerScript player, StateMachine sm) : base(player, sm)
     {
     }

    public override void Enter()
    {
        Debug.Log("entering the crouch state");

        //player.sr.color = new Color(0.1f, 0.9f, 0.3f);  //change the sprite colour
    }


    public override void Exit()
    {
        //exit the Crouch state
    }
    public override void Update()
    {




    }

}
