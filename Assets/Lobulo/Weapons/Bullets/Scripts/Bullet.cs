using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    private void Start()
    {
        gameObject.layer = transform.parent.gameObject.layer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Health health)) health.Damage(10f);
        Destroy(gameObject);
    }
}
