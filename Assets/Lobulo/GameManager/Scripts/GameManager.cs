using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public GameObject Player { get; private set; }
    [field: SerializeField] public GameObject RoomBoss { get; private set; }
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        SinglentonCheckDuplicates();
        Player = GameObject.Find("PlayerContainer");
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
