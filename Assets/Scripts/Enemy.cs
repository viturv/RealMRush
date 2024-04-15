using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int EnemyReward = 25;
    [SerializeField] int EnemyPenalty = 25;
    Bank bank;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }


    public void GoldReward()
    {
        if(bank == null){ return;}
        bank.Deposit(EnemyReward);
    }


    public void GoldPenalty()
    {
        if(bank == null){ return;}
        bank.Withdraw(EnemyPenalty);
    }
    
}
