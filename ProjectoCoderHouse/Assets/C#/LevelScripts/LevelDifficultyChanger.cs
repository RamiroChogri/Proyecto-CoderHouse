using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelDifficultyChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public static event Action PlayerSpeedUpEvent;
    public static event Action WeatherChangeEvent;


    void OnEnable()
    {
        Portal.LevelChangeEvent += LevelDifficultySelector;
    }

    void OnDisable()
    {
        Portal.LevelChangeEvent -= LevelDifficultySelector;
    }


    void LevelDifficultySelector(){
        int eventTrigger = UnityEngine.Random.Range(0,100) % 5;

        if (eventTrigger == 0){
            WeatherChangeEvent?.Invoke();
        }
        else{
            PlayerSpeedUpEvent?.Invoke();
        }
    }
}
