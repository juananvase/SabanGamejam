using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponDataSO _weaponData;
    [SerializeField] private WeaponDataSO _secondWeaponData;
    [SerializeField] private Transform _bulletAnchor;
    [SerializeField] private string _layer;
    
    [SerializeField] private AudioSource _effectsMusicSource;
    [SerializeField] private AudioClip _sfx;
    
    private float _nextFireTime;
    private bool _isCoolingdown => Time.time < _nextFireTime;
    
    private void StartCoolDown() => _nextFireTime = Time.time + _weaponData.CooldownTime;

    public virtual void Shoot()
    {
        if(_isCoolingdown) return;

        if (GameManager.Instance.PerksData.HaveLigthBullets && _secondWeaponData != null) _secondWeaponData.CooldownTime = 0.3f;
        else if(_secondWeaponData != null) _secondWeaponData.CooldownTime = 0.5f;
        
        PlaySound();
        BulletPattern ammoType;
        if (GameManager.Instance.PerksData.HaveStunBullets && _secondWeaponData != null) ammoType = _secondWeaponData.Ammo;
        else ammoType = _weaponData.Ammo;
        
        GameObject ammo = Instantiate(ammoType.gameObject, _bulletAnchor.position, _bulletAnchor.rotation);
        ammo.layer = LayerMask.NameToLayer(_layer);
        
        StartCoolDown();
    }
    
    private void PlaySound()
    {
        _effectsMusicSource.clip = _sfx;
        _effectsMusicSource.Play();
    }
}
