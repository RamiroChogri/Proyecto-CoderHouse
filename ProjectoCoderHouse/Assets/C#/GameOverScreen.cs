
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    List<string> _highScores = new List<string>();
    public Text scoreLabel;
    float[] scores;
    public Text highScoreLabel;
    public Text pastScoresLabel;
    public Text leaderBoardValues;
    // Start is called before the first frame update
    void Start()
    {
        scores = new float[3];
        scores[0] = 10.55f;
        scores[1] = 12.44f;
        scores[2] = 25.11f;

        //Calculo la high score
        string pastScores = "";
        float maxScore = 0;
        for (int i = 0; i<3;i++){
            if (scores[i] > maxScore){
                maxScore = scores[i];
            }
            pastScores += scores[i].ToString();
            pastScores += "\n";
        }
        pastScoresLabel.text = pastScores;
        highScoreLabel.text = maxScore.ToString();
        scoreLabel.text = "Your Score : 25";

        //Los Leaderboards
        _highScores.Add("Roberta 40");
        _highScores.Add("Joaquina 35");
        _highScores.Add("Ana 27");
        _highScores.Add("Naty 18");
        
        string leaderBoard = "";
        foreach(string score in _highScores){
            leaderBoard += score.ToString();
            leaderBoard += "\n";
        }
        leaderBoardValues.text = leaderBoard;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
