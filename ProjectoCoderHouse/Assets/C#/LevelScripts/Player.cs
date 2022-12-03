
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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

    public GameObject effectOne;
    public GameObject effectTwo;

    public GameObject exit;
    public Text energyLabel;
    public GameObject warningPanel;

    public GameObject boom;
    private Transform player;

    short coins = 0;

    public static event Action GameOverEvent;


    void Start()
    {
        player = this.gameObject.transform;
        inputForce = Vector3.zero;
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    void OnEnable()
    {
        LevelDifficultyChanger.PlayerSpeedUpEvent += SpeedUp;
        LevelDifficultyChanger.WeatherChangeEvent += ToggleEffect;
    }

    void OnDisable()
    {
        LevelDifficultyChanger.PlayerSpeedUpEvent -= SpeedUp;
        LevelDifficultyChanger.WeatherChangeEvent -= ToggleEffect;
    }

    void SpeedUp(){
        speed += 5f;
    }

    void ToggleEffect()
    {
        if(effectOne.activeInHierarchy)
        {
            effectOne.SetActive(false);
            effectTwo.SetActive(true);
        }
        else
        {
            effectOne.SetActive(true);
            effectTwo.SetActive(false);
        }
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

    void OnTriggerEnter(Collider colider)
    {
        if(colider.transform.gameObject.tag == "Obstacle"){
            Instantiate(boom,player.position,player.rotation);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject,2f);
            ScoreManager.finalCoins = coins;
            GameOverEvent?.Invoke();
        }

        if(colider.transform.gameObject.name == "Portal"){
            transform.position = exit.transform.position;
        }

        if(colider.transform.gameObject.tag == "Coin"){
            coins++;
        }
    }
}
