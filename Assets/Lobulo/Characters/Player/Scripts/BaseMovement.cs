using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] private MovementSO _movementData;
    private Rigidbody _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void MoveObject(Vector2 value)
    {
        if (value != Vector2.zero)
        {
            Vector3 direction = new Vector3(value.x, 0, value.y);
            _rigidbody.AddForce(direction * _movementData.Acceleration, ForceMode.VelocityChange);

            if (_rigidbody.linearVelocity.magnitude > _movementData.MaxSpeed)
            {
                _rigidbody.linearVelocity = _rigidbody.linearVelocity.normalized *_movementData.MaxSpeed;
            }
        }
        else
        {
            _rigidbody.AddForce(_rigidbody.linearVelocity * -_movementData.Deceleration, ForceMode.VelocityChange);
        }

    }
}
