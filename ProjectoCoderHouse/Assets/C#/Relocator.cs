using System.Transactions;
using System.Threading.Tasks.Dataflow;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relocator : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position.z *= 20f;
    }

    void OnTriggerEnter(Collider colider)
    {
        
    }
}
