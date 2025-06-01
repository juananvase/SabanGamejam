using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Scriptable Objects/PlayerDataSO")]
public class PlayerDataSO : CharacterDataSO
{
    [field: SerializeField] public InputActionAsset InputAction { get; set; }
    [field: SerializeField] public LayerMask GroundMask { get; private set; }
}
