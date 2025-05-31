using UnityEngine;

[CreateAssetMenu(fileName = "MovementSO", menuName = "Scriptable Objects/MovementSO")]
public class MovementSO : ScriptableObject
{
    [field: SerializeField] public float Acceleration { get; private set; } = 1f;
    [field:SerializeField] public float Deceleration { get; private set; } = 1f;
    [field:SerializeField] public float MaxSpeed { get; private set; } = 10f;
    
    [field: SerializeField] public LayerMask GroundMask { get; private set; }
}
