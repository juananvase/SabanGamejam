using UnityEngine;

public class FLBossController : EnemyController
{
    [SerializeField] private float _scapeRange;
    protected bool _needScape = false;
    
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _walkPointRange;
    private Vector3 _walkPoint;
    private bool _walkPointSet = false;

    protected override void Update()
    {
        CheckScapeRange();
        CheckAttackRange();
        if (!_playerInAttackRange && !_needScape) ChasePlayer();
        else if (_needScape) Scape();
        
        if(_playerInAttackRange) AttackPlayer();
    }

    protected void CheckScapeRange()
    {
        if(!_player) return;
        _needScape = Vector3.Distance(transform.position, _player.transform.position) <= _scapeRange;
    }

    protected virtual void Scape()
    {
        if (!_walkPointSet) SearchWalkPoint();
        
        if(_walkPointSet) _agent.SetDestination(_walkPoint);
        
        Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) _walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);
        
        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_walkPoint, -transform.up, 2f, _groundLayer)) _walkPointSet = true;
    }
}
