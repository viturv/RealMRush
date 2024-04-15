using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem PaticleActiver;
    [SerializeField] float range = 15f;
    Transform Target;
    
  
    void Update()
    {
        FindClosestTarget();
        AimEnemy();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;


        foreach(Enemy enemy in enemies)
        {
            float targetDistace = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistace < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistace;
            }


            Target = closestTarget;
        }
    }
    void AimEnemy()
    {
        float TargetDistace = Vector3.Distance(transform.position , Target.position);
        weapon.LookAt(Target);

        if(TargetDistace < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }


    void Attack(bool isActive)
    {
        var emissionModule = PaticleActiver.emission;
        emissionModule.enabled = isActive;
    }
}
