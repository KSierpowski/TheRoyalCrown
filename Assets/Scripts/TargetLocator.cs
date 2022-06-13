using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    Transform target;
    [SerializeField] Transform weapon;
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }


    void Update()
    {
        AimWeapon();
    }


    void AimWeapon()
    {
        weapon.LookAt(target);
    }







}

