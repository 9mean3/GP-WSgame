using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        Vector3 dir = enemy.player.transform.position - enemy.transform.position;
        dir.Normalize();
        enemy.CharacterControllerCompo.Move(dir * 2 * Time.deltaTime);
        if (Vector3.Distance(enemy.player.transform.position, enemy.transform.position) < 5f)
        {
            enemyStateMachine.ChangeState(EnemyStateEnum.Attack);
        }

        if (Vector3.Distance(enemy.player.transform.position, enemy.transform.position) > 15f)
        {
            enemyStateMachine.ChangeState(EnemyStateEnum.Idle);
        }
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
