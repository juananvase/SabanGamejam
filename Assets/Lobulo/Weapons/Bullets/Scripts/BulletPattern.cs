using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletPattern : MonoBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private bool CheckAmmo()
    {
        return transform.childCount <= 0;
    }

    private void OnEnable()
    {
        ApplyForce();
        StartCoroutine(OnEmptyAmmoCoroutine());
    }

    public void ApplyForce()
    {
        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private IEnumerator OnEmptyAmmoCoroutine()
    {
        yield return new WaitUntil(CheckAmmo);
        Destroy(gameObject);
    }
}
