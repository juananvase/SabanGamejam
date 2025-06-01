using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataSO", menuName = "Scriptable Objects/CharacterDataSO")]
public class CharacterDataSO : ScriptableObject
{
    [field: SerializeField] public float MaxHealth { get; private set; } = 100f;
    [field: SerializeField] public float CurrentHealth { get; set; }
    
    [field: SerializeField] public float Acceleration { get; private set; } = 5f;
    [field:SerializeField] public float Deceleration { get; private set; } = 0.3f;
    [field:SerializeField] public float MaxSpeed { get; private set; } = 17f;

    protected void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }
}
