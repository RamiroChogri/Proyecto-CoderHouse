using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    //private int children = 10;
    public GameObject exit;
    // Start is called before the first frame update
    public Vector3 GetExitCoordinates(){
        return exit.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        Transform child = transform.Find("Child02");
    }
}
