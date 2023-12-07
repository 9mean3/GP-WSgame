using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected Player player;
    protected PlayerStateMachine playerStateMachine;

    public PlayerState(Player player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        playerStateMachine = stateMachine;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();

}
