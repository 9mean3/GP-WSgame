using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {

    }

    public override void Update()
    {
        Vector3 moveDir = new Vector3(player.InputReader.Move.x, player.CharacterControllerCompo.velocity.y, player.InputReader.Move.y);
        player.SetVelocity(moveDir);
        Debug.Log(moveDir.ToString() + ' ' + player.CharacterControllerCompo.velocity);
        if(moveDir.magnitude < 0.05f)
        {
            playerStateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {

    }
}
