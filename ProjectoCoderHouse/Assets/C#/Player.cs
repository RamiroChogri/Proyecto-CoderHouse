
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float m_Thrust = 20f;
    Rigidbody m_Rigidbody;
    Vector3 inputForce;

    public GameObject camOne;
    public GameObject camTwo;
    void Start()
    {
        inputForce = Vector3.zero;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update() 
    {
       ToggleCam(); 
    }
    void FixedUpdate()
    {


        inputForce.x = Input.GetAxis("Horizontal");
        inputForce.y = Input.GetAxis("Vertical");
        inputForce.z = 1f;
        m_Rigidbody.AddForce(inputForce * m_Thrust * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    void ToggleCam()
    {
        if(Input.GetKey(KeyCode.V))
        {
            if(camOne.activeInHierarchy)
            {
                camOne.SetActive(false);
                camTwo.SetActive(true);
            }
            else
            {
                camOne.SetActive(true);
                camTwo.SetActive(false);
            }
        }
    }
}
