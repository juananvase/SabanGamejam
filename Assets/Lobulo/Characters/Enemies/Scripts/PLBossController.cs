using UnityEngine;

public class PLBossController : EnemyController
{
    protected override void Update()
    {
        ChasePlayer();
        
        CheckAttackRange();
        if (_playerInAttackRange) AttackPlayer();
    }
}
