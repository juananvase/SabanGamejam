using UnityEngine;

[CreateAssetMenu(fileName = "PerksDataSO", menuName = "Scriptable Objects/PerksDataSO")]
public class PerksDataSO : ScriptableObject
{
    [field: SerializeField] public bool HaveShield {get; set;}
    [field: SerializeField] public bool HaveStunBullets {get; set;}
    [field: SerializeField] public bool HaveLigthBullets {get; set;}
}
