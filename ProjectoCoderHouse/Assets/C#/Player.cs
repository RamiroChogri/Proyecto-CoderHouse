
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject exit;
    public Text energyLabel;

    public GameObject boom;
    public Transform player;
    void Start()
    {
        inputForce = Vector3.zero;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if(!Input.GetMouseButton(0) && energy < MAXENERGY){
            energy += energyRechargeRate * Time.deltaTime;
        }

        if(Input.GetMouseButton(0) && energy > 1f){
            m_AxisMultiplier = 4f;
            energy-=40f * Time.deltaTime;
        }else{
            m_AxisMultiplier = 2f;
        }
        energyLabel.text = "Energy: "+ energy.ToString();
        Debug.Log(m_AxisMultiplier);
        ToggleCam(); 
    }
    void FixedUpdate()
    {   
        inputForce.x = Input.GetAxis("Horizontal")*m_AxisMultiplier;
        inputForce *= m_Thrust;
        m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, m_Thrust);
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
            Destroy(this.gameObject);
        }

        if(colider.transform.gameObject.name == "Portal"){
            transform.position = exit.transform.position;
        }
    }
    void OnDestroy()
    {
        Instantiate(boom,player.position,player.rotation);
    }
}
