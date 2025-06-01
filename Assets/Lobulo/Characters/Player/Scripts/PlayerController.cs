using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    [SerializeField] private PlayerDataSO _playerData;
    [SerializeField] private EmptyEventAsset _onPlayerDeath;
    
    private PlayerMovement _playerMovement;
    private Weapon _weapon;
    
    private InputAction _movementInput;
    private InputAction _shootingInput;

    private void OnEnable()
    {
        _playerData.InputAction.FindActionMap("Gameplay").Enable();
        _onPlayerDeath.AddListener(OnPlayerDeath);
    }
    private void OnDisable()
    {
        _playerData.InputAction.FindActionMap("Gameplay").Disable();
        _onPlayerDeath.RemoveListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        _playerData.InputAction.FindActionMap("Gameplay").Disable();
    }

    private void Awake()
    {
        TryGetComponents();
        FindInputs();
    }

    private void TryGetComponents()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _weapon = GetComponent<Weapon>();
    }

    private void FindInputs()
    {
        _movementInput = InputSystem.actions.FindAction("Movement");
        _shootingInput = InputSystem.actions.FindAction("Shoot");
    }

    private void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!_playerMovement) return;
        _playerMovement.Move(_movementInput.ReadValue<Vector2>());
    }

    private void Shoot()
    {
        if (!_weapon) return;
        
        if (_shootingInput.WasPressedThisFrame())
        {
            _weapon.Shoot();
        }
    }

}
