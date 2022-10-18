using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float m_Thrust = 20f;
    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            m_Rigidbody.AddForce(Vector3.left * 100f * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            m_Rigidbody.AddForce(Vector3.right * 100f * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        m_Rigidbody.AddForce(Vector3.forward * m_Thrust * Time.fixedDeltaTime, ForceMode.Impulse);

    }
}
