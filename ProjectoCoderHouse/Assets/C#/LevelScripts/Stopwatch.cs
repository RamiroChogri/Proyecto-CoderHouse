
using UnityEngine;
using UnityEngine.UI;
using System;


public class Stopwatch : MonoBehaviour
{
    bool stopwatchActive = false;
    float currentTime;
    public Text currentTimeText;

    
    // Start is called before the first frame update
    void Start()
    {
        currentTimeText.enabled = false;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.name == "Player")
        {
            currentTimeText.enabled = true;
            stopwatchActive = true;
        }
    }
}
