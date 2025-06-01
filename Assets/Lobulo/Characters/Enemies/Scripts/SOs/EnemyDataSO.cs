using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Scriptable Objects/EnemyDataSO")]
public class EnemyDataSO : CharacterDataSO
{
    [field: SerializeField] public float AttackRange { get; private set; }
}
