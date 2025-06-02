using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnner : MonoBehaviour
{
    [SerializeField] GameObject[] _enemiesToSpawn;
    [SerializeField] float _spawnCooldown = 3f;
    [SerializeField] GameObjectEventAsset _onCharacterDeath;
    
    private float _nextFireTime;
    private bool _isCoolingdown => Time.time < _nextFireTime;
    private void StartCoolDown() => _nextFireTime = Time.time + _spawnCooldown;

    private void OnEnable()
    {
        if(!_onCharacterDeath)return;
        _onCharacterDeath.AddListener(CheckBossDeath);
    }

    private void OnDisable()
    {
        if(!_onCharacterDeath)return;
        _onCharacterDeath.RemoveListener(CheckBossDeath);
    }

    private void CheckBossDeath(GameObject value)
    {
        if (value == GameManager.Instance.RoomBoss) Destroy(gameObject);
    }

    private void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if(_isCoolingdown) return;
        SpawnedFeedback();
        Instantiate(_enemiesToSpawn[Random.Range(0, _enemiesToSpawn.Length)], transform.position, transform.rotation);
        StartCoolDown();
    }

    private void SpawnedFeedback()
    {
        //TODO: Add feedback
    }
}
