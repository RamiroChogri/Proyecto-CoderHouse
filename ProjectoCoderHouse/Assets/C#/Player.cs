
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
        if(energy < MAXENERGY){
            energy += energyRechargeRate * Time.deltaTime;
        }

        if(Input.GetMouseButton(0) && energy > 0f){
            m_AxisMultiplier = 4f;
            energy-=10f * Time.deltaTime;
        }else{
            m_AxisMultiplier = 2f;
        }

        ToggleCam(); 
    }
    void FixedUpdate()
    {   
        

        inputForce.x = Input.GetAxis("Horizontal")*m_AxisMultiplier;
        inputForce.z = 1;
        inputForce *= m_Thrust;
        m_Rigidbody.AddForce(inputForce * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    void ToggleCam()
    {
        if(Input.GetKeyDown(KeyCode.V))
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

    void OnTriggerEnter(Collider colider)
    {
        if(colider.transform.gameObject.tag == "Obstacle"){
            Destroy(this);
        }
    }
}
