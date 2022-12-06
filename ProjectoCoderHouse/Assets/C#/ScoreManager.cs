using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager Instance = null;
    public static int finalCoins = 0;
    public static float finalTime = 0;
    public static float finalScore = 0;
    public static float[] pastScores = new float[5];
    int scoreAmount = 0;

    void OnEnable()
    {
        Stopwatch.TimerStopped += CalculateScore;
    }

    void OnDisable()
    {
        Stopwatch.TimerStopped -= CalculateScore;
    }

    private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
    }

    void ResetScore(){
        finalTime = 0;
        finalCoins = 0;
        finalScore = 0;
    }

    void CalculateScore(){
        finalScore = finalTime + 100 * finalCoins;
        if (scoreAmount > 4) {
            pastScores[scoreAmount] = finalScore;
            scoreAmount++;
        }else{
            scoreAmount=0;
        }
    }
}
