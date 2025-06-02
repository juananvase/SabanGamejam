using UnityEngine;

public class OLBossController : FLBossController
{
    protected override void Update()
    {
        CheckScapeRange();
        CheckAttackRange();
        
        if (_needScape) Scape();
        else if(_playerInAttackRange) AttackPlayer();
    }
}
