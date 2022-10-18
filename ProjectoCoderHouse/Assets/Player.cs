using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float m_Thrust = 20f;
    Rigidbody m_Rigidbody;
    Vector3 inputForce;
    void Start()
    {
        inputForce = Vector3.zero;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        inputForce.x = Input.GetAxis("Horizontal");
        inputForce.y = Input.GetAxis("Vertical");
        inputForce.z = 20f;
        m_Rigidbody.AddForce(inputForce * m_Thrust * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
