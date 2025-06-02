using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Weapon))]
public class EnemyController : CharacterController
{
    [SerializeField] private EnemyDataSO _enemyData;
    [SerializeField] private LayerMask _playerLayer;
    protected NavMeshAgent _agent;
    private Weapon _weapon;
    protected Transform _player;
    protected bool _playerInAttackRange = false;
    
    private bool _isStun = false;

    protected virtual void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _weapon = GetComponent<Weapon>();
    }
    
    protected virtual void Start()
    {
        _player = GameManager.Instance.Player.transform;
    }
    
    protected virtual void Update()
    {
        if(_isStun) return;
        
        CheckAttackRange();
        if (!_playerInAttackRange) ChasePlayer();
        else AttackPlayer();
    }

    public override void OnStunned()
    {
        StartCoroutine(ExitStunCoroutine());
    }

    private IEnumerator ExitStunCoroutine()
    {
        _isStun = true;
        yield return new WaitForSeconds(1.7f);
        _isStun = false;
    }

    protected virtual void ChasePlayer()
    {
        if(!_player) return;
        _agent.SetDestination(_player.position);
    }
    
    protected void AttackPlayer()
    {
        transform.LookAt(_player);

        _weapon.Shoot();
    }

    protected void CheckAttackRange()
    {
        _playerInAttackRange = Physics.CheckSphere(transform.position, _enemyData.AttackRange, _playerLayer);
    }
}
