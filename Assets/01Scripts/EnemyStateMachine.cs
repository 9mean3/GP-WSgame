using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateEnum
{
    Idle,
    Chase,
    Attack,
}

public class EnemyStateMachine 
{
    public EnemyState CurrentState { get; private set; }
    private EnemyState beforeState;
    public Dictionary<EnemyStateEnum, EnemyState> StateDictionary = new Dictionary<EnemyStateEnum, EnemyState>();

    private Enemy enemy;

    public void Initialize(EnemyStateEnum stateEnum, Enemy enemy)
    {
        this.enemy = enemy;
        CurrentState = StateDictionary[stateEnum];
        beforeState = CurrentState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyStateEnum stateEnum) 
    {
        CurrentState.Exit();
        beforeState = CurrentState;
        CurrentState = StateDictionary[stateEnum];
        CurrentState.Enter();
    }

    public void AddState(EnemyStateEnum stateEnum, EnemyState instance)
    {
        StateDictionary.Add(stateEnum, instance);
    }
}
