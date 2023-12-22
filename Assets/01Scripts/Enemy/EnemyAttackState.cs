using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (Vector3.Distance(enemy.player.transform.position, enemy.transform.position) > 5f)
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
