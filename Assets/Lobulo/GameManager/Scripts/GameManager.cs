using System;
using FischlWorks_FogWar;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public GameObject Player { get; private set; }
    [field: SerializeField] public Camera Camera { get; private set; }
    [field: SerializeField] public GameObject RoomBoss { get; private set; }
    [field: SerializeField] public csFogWar FogWar { get; private set; }
    [field: SerializeField] public PerksDataSO PerksData { get; private set; }

    [SerializeField] private bool _haveShield;
    [SerializeField] private bool _haveStunBulet;
    [SerializeField] private bool _haveLigthBullets;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        SinglentonCheckDuplicates();
        Player = GameObject.Find("PlayerContainer");
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();

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
