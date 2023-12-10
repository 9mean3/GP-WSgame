using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public enum PlayerStateEnum
{
    Idle,
    Move,
}

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }
    private PlayerState beforeState;
    public Dictionary<PlayerStateEnum, PlayerState> StateDictionary = new Dictionary<PlayerStateEnum, PlayerState>();

    private Player player;

    public void Initialize(PlayerStateEnum stateEnum, Player player)
    {
        this.player = player;
        CurrentState = StateDictionary[stateEnum];
        beforeState = CurrentState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerStateEnum stateEnum)
    {
        Debug.Log($"State Change: {beforeState.ToString()} to {CurrentState.ToString()}");
        CurrentState.Exit();
        beforeState = CurrentState;
        CurrentState = StateDictionary[stateEnum];
        CurrentState.Enter();
    }

    public void AddState(PlayerStateEnum state, PlayerState instance)
    {
        StateDictionary.Add(state, instance);
    }
}
