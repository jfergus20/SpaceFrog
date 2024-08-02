using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI highScoreText;

    private int score = 0;
    private int highScore = 0;
    public static ScoreManager instance;
    //public static ScoreManager Instance { get; private set; }

    /*private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the ScoreManager between scenes.
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    // Add your score management functions here.
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score); // Save high score to PlayerPrefs.
        }
    }

}



/*
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;          // Reference to the Text element displaying the score.
    public TextMeshProUGUI highScoreText;      // Reference to the Text element displaying the high score.

    private int score = 0;
    private int highScore = 0;

    private void Start()
    {
        // Load the high score from PlayerPrefs (if available).
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    private void Update()
    {
        // Example: Increase the score when an event occurs.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseScore(10);
        }
    }

    public void IncreaseScore(int amount)
    {
        //Debug.Log("score increased");
        score += amount;
        UpdateScoreText();

        if (score > highScore)
        {
            highScore = score;
            UpdateHighScoreText();
            PlayerPrefs.SetInt("HighScore", highScore); // Save high score to PlayerPrefs.
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore;
    }
}
*/