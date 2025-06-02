using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public GameObject Player { get; private set; }
    [field: SerializeField] public GameObject RoomBoss { get; private set; }
    [field: SerializeField] public PerksDataSO PerksData { get; private set; }

    [SerializeField] private bool _haveShield;
    [SerializeField] private bool _haveStunBulet;
    [SerializeField] private bool _haveLigthBullets;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        SinglentonCheckDuplicates();
        Player = GameObject.Find("PlayerContainer");

        PerksData.HaveShield = _haveShield;
        PerksData.HaveLigthBullets = _haveLigthBullets;
        PerksData.HaveStunBullets = _haveStunBulet;
    }

    private void SinglentonCheckDuplicates()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    
}
