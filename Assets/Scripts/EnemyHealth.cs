using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy ))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxhitpoints = 5;
    [Tooltip("This will decide how much hitpoints will increase once the enemy is being killed by the tower")]
    [SerializeField] int DifficultyRamp = 2;

    int currenthitpoint = 0;
    Enemy enemy;


    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        currenthitpoint=maxhitpoints;
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    void ProcessHit()
    {
        currenthitpoint--;

        if (currenthitpoint <= 0)
        {   
            gameObject.SetActive(false);
            maxhitpoints += DifficultyRamp;
            enemy.GoldReward();
        }
    }
}
