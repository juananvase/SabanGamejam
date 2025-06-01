using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Weapon))]
public class EnemyController : CharacterController
{
    [SerializeField] private EnemyDataSO _enemyData;
    [SerializeField] private LayerMask _playerLayer;
    private NavMeshAgent _agent;
    private Weapon _weapon;
    private Transform _player;
    private bool _playerInAttackRange = false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _weapon = GetComponent<Weapon>();
    }

    private void Start()
    {
        _player = GameManager.Instance.Player.transform;
    }

    private void Update()
    {
        CheckAttackRange();
        if (!_playerInAttackRange) ChasePlayer();
        else AttackPlayer();
    }

    private void ChasePlayer()
    {
        if(!_player) return;
        _agent.SetDestination(_player.position);
    }
    
    private void AttackPlayer()
    {
        transform.LookAt(_player);

        _weapon.Shoot();
    }

    private void CheckAttackRange()
    {
        _playerInAttackRange = Physics.CheckSphere(transform.position, _enemyData.AttackRange, _playerLayer);
    }
}
