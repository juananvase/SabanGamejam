using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponDataSO _weaponData;
    [SerializeField] private Transform _bulletAnchor;
    [SerializeField] private string _layer;
    
    private float _nextFireTime;
    private bool _isCoolingdown => Time.time < _nextFireTime;
    
    private void StartCoolDown() => _nextFireTime = Time.time + _weaponData.CooldownTime;

    public virtual void Shoot()
    {
        if(_isCoolingdown) return;
        GameObject Ammo = Instantiate(_weaponData.Ammo.gameObject, _bulletAnchor.position, _bulletAnchor.rotation);
        Ammo.layer = LayerMask.NameToLayer(_layer);
        StartCoolDown();
    }
}
