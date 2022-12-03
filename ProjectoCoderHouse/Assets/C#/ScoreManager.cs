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


    void OnEnable()
    {
        Player.GameOverEvent += CalculateScore;
    }

    void OnDisable()
    {
        Player.GameOverEvent -= CalculateScore;
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
        Debug.Log("Puntaje Reseteado");
        finalTime = 0;
        finalCoins = 0;
        finalScore = 0;
    }

    void CalculateScore(){
        Debug.Log("Puntaje Calculado");
        finalScore = finalTime + 100 * finalCoins;
    }
}
