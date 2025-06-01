using System;
using UnityEngine;

public class TestShoot : MonoBehaviour
{
    private Weapon _weapon;
    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        _weapon.Shoot();
    }
}
