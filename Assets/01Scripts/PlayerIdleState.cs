using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        player.StopImmediately();
    }

    public override void Update()
    {
        if (player.InputReader.Move.magnitude >= 0.05f)
        {
            playerStateMachine.ChangeState(PlayerStateEnum.Move);
        }
    }

    public override void Exit()
    {

    }
}
