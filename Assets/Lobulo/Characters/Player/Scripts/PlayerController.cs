using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    [SerializeField] private PlayerDataSO _playerData;
    [SerializeField] private GameObjectEventAsset _onPlayerDeath;
    
    private bool _canMove = true;
    
    private PlayerMovement _playerMovement;
    private Weapon _weapon;
    private Shield _shield;
    
    private InputAction _movementInput;
    private InputAction _shootingInput;
    private InputAction _shieldInput;

    public override void OnStunned()
    {
        StartCoroutine(ExitStunCoroutine());
    }

    private IEnumerator ExitStunCoroutine()
    {
        _canMove = false;
        yield return new WaitForSeconds(1.3f);
        _canMove = true;
    }

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

    private void OnPlayerDeath(GameObject value)
    {
        if(value != gameObject) return;
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
        _shield = GetComponent<Shield>();
    }

    private void FindInputs()
    {
        _movementInput = InputSystem.actions.FindAction("Movement");
        _shootingInput = InputSystem.actions.FindAction("Shoot");
        _shieldInput = InputSystem.actions.FindAction("Shield");
    }

    private void Update()
    {
        Shoot();
        UseShield();
    }

    private void UseShield()
    {
        if (!_shield || !GameManager.Instance.PerksData.HaveShield) return;
        if ( _shieldInput.WasPressedThisFrame())
        {
            _shield.UseShield();
        }
        else if(_shieldInput.WasReleasedThisFrame())
        {
            _shield.StopShield();
        }
    }

    private void FixedUpdate()
    {
        if(_canMove) Move();
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
