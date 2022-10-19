using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider colider)
    {
        if(colider.transform.gameObject.tag == "Relocator"){
            transform.position = new Vector3(Random.Range(-9f,29f),0.5f,transform.position.z);
        }
    }
}
