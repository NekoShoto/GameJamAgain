using UnityEngine;
using UnityEngine.UI; // Only needed if displaying the score with UI

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public float pointsPerSecond = 1; // Change this for your preferred rate
    public Text scoreText; // Attach your UI Text component here

    public int scoreMedKit;
    public int scoreBaseballBat;
    public int scorePistol;

    public int scoreItems;


    void Update()
    {
        score += pointsPerSecond * Time.deltaTime;
        //scoreCount = 
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score + scoreItems).ToString();
        }
            
    }


    public void MedKitScore()
    {
        scoreItems = scoreItems + scoreMedKit;
    }

    public void BaseballBatScore()
    {
        scoreItems = scoreItems + scoreBaseballBat;
    }

    public void Pistol()
    {
        scoreItems = scoreItems + scorePistol;
    }


}
