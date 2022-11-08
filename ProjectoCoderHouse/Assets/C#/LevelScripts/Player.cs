
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Dsp de cada entrada al portal agregar velocidad
    float m_Thrust = 20f;
    float m_AxisMultiplier = 2f;
    Rigidbody m_Rigidbody;
    public float speed = 40f;

    float MAXENERGY = 100f;
    float energy = 100f;
    float energyRechargeRate = 20f;
    Vector3 inputForce;

    public GameObject camOne;
    public GameObject camTwo;

    public GameObject exit;
    public Text energyLabel;
    public GameObject warningPanel;

    public GameObject boom;
    private Transform player;
    void Start()
    {
        player = this.gameObject.transform;
        inputForce = Vector3.zero;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if(!Input.GetMouseButton(0) && energy < MAXENERGY){
            energy += energyRechargeRate * Time.deltaTime;
        }

        if(Input.GetMouseButton(0) && energy > 1f){
            m_AxisMultiplier = 6f;
            energy-=40f * Time.deltaTime;
        }else{
            m_AxisMultiplier = 2f;
        }
        energyLabel.text = "Energy: "+ energy.ToString();
        ToggleCam(); 
    }
    void FixedUpdate()
    {   
        inputForce.x = Input.GetAxis("Horizontal")*m_AxisMultiplier;
        inputForce *= m_Thrust; 
        m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, speed);
        m_Rigidbody.AddForce(inputForce * Time.fixedDeltaTime, ForceMode.Impulse);

        
        if (Physics.Raycast(transform.position, Vector3.forward, 30)){
            warningPanel.SetActive(true);
        }else{
            warningPanel.SetActive(false);
        }
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
            Instantiate(boom,player.position,player.rotation);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject,2f);
            SceneManager.LoadScene(1);
        }

        if(colider.transform.gameObject.name == "Portal"){
            transform.position = exit.transform.position;
        }
    }
}
