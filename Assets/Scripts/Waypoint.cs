using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    void OnMouseDown()
    {
        Debug.Log(transform.name);
    }


}