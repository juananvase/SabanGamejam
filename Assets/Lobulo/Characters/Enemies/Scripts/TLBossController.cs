using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TLBossController : EnemyController
{
    [SerializeField] private float _TeleportCoolDown;
    [SerializeField] private Transform[] _teleportPlaces;
    private float _nextFireTime;
    private bool _isCoolingdown => Time.time < _nextFireTime;
    private void StartCoolDown() => _nextFireTime = Time.time + _TeleportCoolDown;

    protected override void Update()
    {
        CheckAttackRange();
        if(_playerInAttackRange) AttackPlayer();
        
        if(_isCoolingdown) return;
        Teleport();
        StartCoolDown();
    }

    private void Teleport()
    {
        Vector3 teleportPosition = _teleportPlaces[Random.Range(0, _teleportPlaces.Length)].position;
        transform.position = teleportPosition;
    }
}
