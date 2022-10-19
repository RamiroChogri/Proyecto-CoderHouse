
using UnityEngine;

public class Relocator : MonoBehaviour
{

    public GameObject exit;
    private Rigidbody m_Rigidbody;
    private Vector3 zAxis = new Vector3(0,0,1);

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_Rigidbody.velocity = zAxis * 40f;
    }

    void OnTriggerEnter(Collider colider)
    {
        if(colider.transform.gameObject.name == "Portal"){
            transform.position = exit.transform.position;
        }
    }
}
