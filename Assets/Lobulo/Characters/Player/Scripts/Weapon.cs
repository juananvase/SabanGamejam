using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private float _force;

    private void Shoot()
    {
        GameObject bullet = SpawnBulllet();
        bullet.GetComponent<Rigidbody>().AddForce(_bulletSpawn.forward * _force, ForceMode.Impulse);
    }

    private GameObject SpawnBulllet()
    {
        GameObject bullet = Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);
        return bullet;
    }
}
