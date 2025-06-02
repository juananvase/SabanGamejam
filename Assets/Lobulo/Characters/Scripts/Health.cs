using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour, IHealable, IDamagable
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private CharacterDataSO _characterData;
    [SerializeField] private GameObjectEventAsset _onCharacterDeath;
    [SerializeField] private Death _death;

    private void OnEnable()
    {
        _currentHealth = _characterData.MaxHealth;
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _characterData.MaxHealth);
    }

    public void Damage(float amount)
    {
        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _characterData.MaxHealth);
        
        if(_currentHealth <= 0) StartCoroutine(OnPlayerDeathCoroutine());
    }

    private IEnumerator OnPlayerDeathCoroutine()
    {
        _death.DeathFunctionality();
        yield return new WaitForSeconds(3f);
        _death.DeathScene();
        _onCharacterDeath?.Invoke(gameObject);
        Destroy(gameObject);
    }
}

