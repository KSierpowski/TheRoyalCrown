using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;



    void Start()
    {
        StartCoroutine(FollowPath());
        
    }
    IEnumerator FollowPath()   //po 1 sekundzie przeskakuje do kolejnego waypoint i wyswietla go w konsoli
    { 
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }

}
