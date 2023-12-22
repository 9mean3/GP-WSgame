using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     public Player player;

    public CharacterController CharacterControllerCompo { get; private set; }
    public EnemyStateMachine StateMachine { get; private set; }

    private void Awake()
    {
        CharacterControllerCompo = GetComponent<CharacterController>();
        StateMachine = new EnemyStateMachine();

        foreach (EnemyStateEnum stateEnum in Enum.GetValues(typeof(EnemyStateEnum)))
        {
            string typeName = stateEnum.ToString();
            try
            {
                Type type = Type.GetType($"Enemy{typeName}State");
                EnemyState instance = Activator.CreateInstance(type, this, StateMachine) as EnemyState;
                StateMachine.AddState(stateEnum, instance);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        StateMachine.Initialize(EnemyStateEnum.Idle, this);
    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
    }
}
