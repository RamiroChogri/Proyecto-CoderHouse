
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float m_Thrust = 20f;
    float m_AxisMultiplier = 2f;
    Rigidbody m_Rigidbody;

    float MAXENERGY = 100f;
    float energy = 100f;
    float energyRechargeRate = 20f;
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
        if(energy < MAXENERGY){
            energy += energyRechargeRate;
        }

        if(Input.GetMouseButton(0) && energy > 0f){
            m_AxisMultiplier = 4f;
            energy-=10f;
        }else{
            m_AxisMultiplier = 2f;
        }

        inputForce.x = Input.GetAxis("Horizontal")*m_AxisMultiplier;
        inputForce.z = 1;
        inputForce *= m_Thrust;
        m_Rigidbody.AddForce(inputForce * Time.fixedDeltaTime, ForceMode.Impulse);
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
