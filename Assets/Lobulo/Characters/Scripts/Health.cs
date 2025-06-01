using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour, IHealable, IDamagable
{
    [SerializeField] private CharacterDataSO _characterData;
    [SerializeField] private EmptyEventAsset _onCharacterDeath;
    [SerializeField] private Death _death;

    public void Heal(float amount)
    {
        _characterData.CurrentHealth += amount;
        _characterData.CurrentHealth = Mathf.Clamp(_characterData.CurrentHealth, 0f, _characterData.MaxHealth);
    }

    public void Damage(float amount)
    {
        _characterData.CurrentHealth -= amount;
        _characterData.CurrentHealth = Mathf.Clamp(_characterData.CurrentHealth, 0f, _characterData.MaxHealth);
        
        if(_characterData.CurrentHealth <= 0) StartCoroutine(OnPlayerDeathCoroutine());
    }

    private IEnumerator OnPlayerDeathCoroutine()
    {
        _death.DeathFunctionality();
        yield return new WaitForSeconds(3f);
        _onCharacterDeath?.Invoke();
        Destroy(gameObject);
    }
}
