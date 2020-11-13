using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {

    int scorePlayer1;
    int scorePlayer2;

    int scoreToWin = 5;

    public Text scorePlayer1Text;
    public Text scorePlayer2Text;
    public Text winner;

    float winCooldown;

    string currentText = "Goal: 5 Points";

    void Start() {

        ResetScore();
        UpdateGUI();

        currentText = "Goal: 5 Points";
        winCooldown = 3.5f;
    }

    void Update() {
        
        if(winCooldown > 0.0f) {

            winCooldown -= Time.deltaTime;
            winner.text = currentText + "\n" + (int) winCooldown;
        } else {

            winner.text = "";
        }
    }

    void ResetScore() {

        scorePlayer1 = 0;
        scorePlayer2 = 0;
        UpdateGUI();
    }

    public void GoalPlayer1() {

        scorePlayer1++;
        UpdateGUI();
        EvalualteWinCondition();
    }

    public void GoalPlayer2() {

        scorePlayer2++;
        UpdateGUI();
        EvalualteWinCondition();
    }

    void EvalualteWinCondition() {

        if (scorePlayer1 >= scoreToWin || scorePlayer2 >= scoreToWin) {

            if (scorePlayer1 > scorePlayer2) {

                currentText = "Player 1 wins";
            }
            else {

                currentText = "Player 2 wins";
            }
            winCooldown = 3.5f;
            ResetScore();
        }  else {

            currentText = "";

            winCooldown = 3.5f;
        }
    }

    void UpdateGUI() {

        scorePlayer1Text.text = scorePlayer1.ToString();
        scorePlayer2Text.text = scorePlayer2.ToString();
    }
}
