using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int StartingBalance = 150;
    
    int currentbalance;
    public int Currentbalnce{get {return currentbalance;}}
    
    [SerializeField] TextMeshProUGUI DisplayBalance;

    void Awake()
    {
        currentbalance = StartingBalance;
        UpdaateDisplayBalance();
    }

    public void Deposit(int amount)
    {
        currentbalance += Mathf.Abs(amount);
        UpdaateDisplayBalance();
    }


    public void Withdraw(int amount)
    {
        currentbalance -= Mathf.Abs(amount);
        UpdaateDisplayBalance();

        if(currentbalance<0)
        {
            ReloadScene();
        }
    }

    void UpdaateDisplayBalance()
    {
        DisplayBalance.text = "Gold: " + currentbalance;
    }


   void ReloadScene()
    {
        Scene currentScene =  SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
