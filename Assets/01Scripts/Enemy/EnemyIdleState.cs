using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void Enter()
    {
        enemy.CharacterControllerCompo.Move(Vector3.zero);
        base.Enter();
    }

    public override void Update()
    {
        if(Vector3.Distance(enemy.player.transform.position, enemy.transform.position) < 10f)
        {
            enemyStateMachine.ChangeState(EnemyStateEnum.Chase);
        }
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

}
