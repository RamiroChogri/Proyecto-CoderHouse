using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Portal : MonoBehaviour
{

    public static event Action LevelChangeEvent;
    public GameObject exit;
    // Start is called before the first frame update
    public Vector3 GetExitCoordinates(){
        return exit.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Portal llamo Level Change Event");
        LevelChangeEvent?.Invoke();
    }

}
