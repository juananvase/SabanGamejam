using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour, IPickupable
{
    [SerializeField] private PickupType _pickupType;
    private GameObject _player;

    private void Start()
    {
        _player = GameManager.Instance.Player;
    }

    public virtual void OnPickup()
    {
        switch(_pickupType) 
        {
            case PickupType.Shield:
                GameManager.Instance.PerksData.HaveShield = true;
                break;
            case PickupType.StunBullet:
                GameManager.Instance.PerksData.HaveStunBullets = true;
                break;
            case PickupType.LigthBullet:
                GameManager.Instance.PerksData.HaveLigthBullets = true;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != _player) return;
        OnPickup();
        Destroy(gameObject);
    }
}

public enum PickupType
{
    Shield,
    StunBullet,
    LigthBullet
}
