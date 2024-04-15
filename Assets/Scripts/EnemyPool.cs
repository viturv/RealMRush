using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0,50)]int PoolSize = 5;
    [SerializeField][Range(0.1f, 30f)] float spawninterval = 5f;
    GameObject[] pool;


    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(EnemyInitiator());        
    }


    void PopulatePool()
    {
        pool = new GameObject[PoolSize];

        for (int i = 0; i< pool.Length ; i++)
        {
            pool[i] = Instantiate(enemy,transform);
            pool[i].SetActive(false);
        }
    }


    void EnableEnemyInPool()
    {
        for(int i = 0; i<pool.Length;i++)
        {
            if(!pool[i].activeInHierarchy) 
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator EnemyInitiator()
    {
        while (true)
        {
            EnableEnemyInPool();
            yield return new WaitForSeconds(spawninterval);
        }
    }
}
