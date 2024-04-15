using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField][Range(0f,5f)] float EnemySpeed= 1f;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(PathOfEnemy());
        
    }
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }


    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            WayPoint wayPoint = child.GetComponent<WayPoint>();
            

            if(path != null)
            {
                path.Add(wayPoint);
        
            }
        }

    }


    void FinishPath()
    {
        enemy.GoldPenalty();
        gameObject.SetActive(false);
    
    }


    IEnumerator PathOfEnemy()
    {
        foreach (WayPoint waypoint in path)
        {
            Vector3 StartPosition = transform.position;
            Vector3 EndPosition = waypoint.transform.position;
            float Movepercent = 0f;

            transform.LookAt(EndPosition);

            while(Movepercent < 1f )
            {
                Movepercent += Time.deltaTime * EnemySpeed;
                transform.position = Vector3.Lerp(StartPosition,EndPosition,Movepercent)  ;
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }


}
