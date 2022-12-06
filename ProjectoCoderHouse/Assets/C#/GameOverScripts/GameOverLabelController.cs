
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverLabelController : MonoBehaviour
{
    List<string> _highScores = new List<string>();
    public Text scoreLabel;
    public Text highScoreLabel;
    public Text pastScoresLabel;


    Dictionary<string,int> ranks = new Dictionary<string,int>();
    // Start is called before the first frame update
    void Start()
    {
        //Calculo la high score
        string pastScores = "";
        float maxScore = 0;
        for (int i = 0; i<5;i++){
            if (ScoreManager.pastScores[i] > maxScore){
                maxScore = ScoreManager.pastScores[i];
            }
            Debug.Log(ScoreManager.pastScores[i]);
            pastScores += ScoreManager.pastScores[i].ToString();
            pastScores += "\n";
        }
        pastScoresLabel.text = pastScores;
        highScoreLabel.text = maxScore.ToString();
        scoreLabel.text = "Your Score : " + ScoreManager.finalScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
