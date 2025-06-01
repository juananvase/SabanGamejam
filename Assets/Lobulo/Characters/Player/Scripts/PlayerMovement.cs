using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataData;
    private Rigidbody _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 value)
    {
        if (value != Vector2.zero)
        {
            Vector3 direction = new Vector3(value.x, 0, value.y);
            _rigidbody.AddForce(direction * playerDataData.Acceleration, ForceMode.VelocityChange);

            if (_rigidbody.linearVelocity.magnitude > playerDataData.MaxSpeed)
            {
                _rigidbody.linearVelocity = _rigidbody.linearVelocity.normalized *playerDataData.MaxSpeed;
            }
        }
        else
        {
            _rigidbody.AddForce(_rigidbody.linearVelocity * -playerDataData.Deceleration, ForceMode.VelocityChange);
        }

    }
}
