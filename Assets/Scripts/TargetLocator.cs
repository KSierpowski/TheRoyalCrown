using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    Transform target;
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticles;



    void Update()
    {
        FindNearestTarget();
        AimWeapon();
        
    }

    void FindNearestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform nearestTarget = null;   //null bo jeszcze go nie znaleüliúmy
        float maxDistance = Mathf.Infinity;   //najwieksza liczba

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                nearestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = nearestTarget;
    }
    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else {Attack(false);}
    }


    void Attack(bool isActive)
    {
     
            var emmisionModule = projectileParticles.emission;
            emmisionModule.enabled = isActive;

    }




}

