using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;



    void Start()
    {

        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
        
    }

    void FindPath()
    {
        path.Clear();   //jak znajdzie œcie¿ke to wyczyœci istniej¹c¹ i doda now¹

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");   //znajdzie to wsystko z tagiem path i umiesci w tablicy

        foreach (GameObject waypoint in waypoints)        
        {  
            path.Add(waypoint.GetComponent<Waypoint>()); //doda go do listy 
        }
    }

    void ReturnToStart()  //zawsze zacznie na pocz¹tku œcie¿ki
    {
        transform.position = path[0].transform.position;   
    }
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        Destroy(gameObject);
    }

}


