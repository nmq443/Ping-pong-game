using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public float gameSpeed {get; private set;}
    private int playerScore;
    private int computerScore;
    [SerializeField] PlayerController player;
    [SerializeField] private float initialGameSpeed = 5f;
    [SerializeField] private float gameSpeedIncrement = 0.1f;
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text computerScoreText;
    [SerializeField] private Text timer;
    [SerializeField] Ball ball;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Text winnerText;
    [SerializeField] private float remainingTime = 60f;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else 
            DestroyImmediate(gameObject);
    }

    private void OnDestroy() {
        if (Instance == this)
            Instance = null;
    }

    private void Update() {
        // timer
        // while playing
        if (remainingTime >= 0) {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.RoundToInt(remainingTime) / 60;
            int second = Mathf.RoundToInt(remainingTime) % 60;
            timer.text = minutes.ToString("00") + ":" + second.ToString("00");
            player.PlayerMovement();
        } else { // end game
            ball.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
            if (computerScore > playerScore)
                winnerText.text = "Computer won!";
            else if (computerScore < playerScore)
                winnerText.text = "You won!";
            else 
                winnerText.text = "Draw!";
        }
        gameSpeed += gameSpeedIncrement * Time.deltaTime;
        // score of 2 players
        // player's score
        playerScoreText.text = playerScore.ToString();

        // computer's score
        computerScoreText.text = computerScore.ToString();
    }

    private void Start() {
        gameSpeed = initialGameSpeed;
        playerScore = computerScore = 0;
        ball.StartGame();
    }

    public void PlayerScore() {
        ++playerScore;
    }
    public void ComputerScore() {
        ++computerScore;
    }

    public void RetryButton() {
        SceneManager.LoadScene("SampleScene");
    }
}
