using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    public Text winText;
    public int maxScore = 10;
    public GameObject ball;

    private int redPlayerScore = 0;
    private int bluePlayerScore = 0;

    private void Start() {
        winText.gameObject.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void UpdateScore(int player) {
        if (player == 1) {
            redPlayerScore++;
        } else {
            bluePlayerScore++;
        }

        scoreText.text = redPlayerScore + " - " + bluePlayerScore;
        CheckWinCondition(player);
    }

    private void CheckWinCondition(int player) {
        if (redPlayerScore >= maxScore || bluePlayerScore >= maxScore) {
            ball.SetActive(false);
            winText.gameObject.SetActive(true);
            winText.text = (player == 1 ? "Red" : "Blue") + " Player Wins!";
            winText.color = (player == 1 ? Color.red : Color.blue);
        }
    }
}
