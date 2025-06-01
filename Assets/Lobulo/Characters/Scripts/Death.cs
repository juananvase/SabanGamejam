using System;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private Collider[] _colliders;
    [SerializeField] private Rigidbody[] _rigidbodies;

    public void DeathFunctionality()
    {
        ChangeLayerToDeath();
        Disarmament();
    }

    private void ChangeLayerToDeath()
    {
        gameObject.layer = LayerMask.NameToLayer("Death");
        foreach (Collider collider in _colliders)
        {
            collider.gameObject.layer = LayerMask.NameToLayer("Death");
        }
    }

    private void Disarmament()
    {
        foreach (Collider collider in _colliders)
        {
            collider.enabled = true;
        }
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(250f, transform.position, 3f);
        }
    }
}
