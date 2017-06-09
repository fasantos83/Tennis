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

    private int playerOneScore = 0;
    private int playerTwoScore = 0;

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
            playerOneScore++;
        } else {
            playerTwoScore++;
        }

        scoreText.text = playerOneScore + " - " + playerTwoScore;
        CheckWinCondition(player);
    }

    private void CheckWinCondition(int player) {
        if (playerOneScore >= maxScore || playerTwoScore >= maxScore) {
            ball.SetActive(false);
            winText.gameObject.SetActive(true);
            winText.text = "Player " + (player == 1 ? "One" : "Two") + " Wins!";
            winText.color = (player == 1 ? Color.red : Color.blue);
        }
    }
}
