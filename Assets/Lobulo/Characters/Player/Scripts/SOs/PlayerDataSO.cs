using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Scriptable Objects/PlayerDataSO")]
public class PlayerDataSO : CharacterDataSO
{
    [field: SerializeField] public float Acceleration { get; private set; } = 5f;
    [field:SerializeField] public float Deceleration { get; private set; } = 0.3f;
    [field:SerializeField] public float MaxSpeed { get; private set; } = 17f;
    [field: SerializeField] public InputActionAsset InputAction { get; set; }
    [field: SerializeField] public LayerMask GroundMask { get; private set; }
}
