using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Scriptable Objects/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public BulletPattern Ammo { get; private set; }
    [field: SerializeField] public float CooldownTime { get; set; }
}
