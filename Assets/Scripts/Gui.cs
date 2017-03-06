using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Gui : MonoBehaviour {
    public Text timeText;
    public Text scoreText;
    public float time = 120;
    string[] highScores;
    int score;
	// Use this for initialization
	void Start () {
        highScores = new string[10];

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timeText.text = "Time: "+ makeTime();
        scoreText.text = score.ToString();
	}
    string makeTime()
    {
        time -= Time.deltaTime;
        if (time <= 0f)
                gameOver();
        string modifiedTime = ((int)(time / 60f)) + ":" + ((int)time%60);
        return modifiedTime;
    }
    void gearScore() {
        score += (int)time * 42;
    }
    void scale() {
        Debug.Log(time);
        score += (int)((30 - time)*40);
    }
    void gameOver() {
        Time.timeScale = 0;
    }

    private string makeString() {
        string forRet ="";
        foreach(string s in highScores){
            forRet += s;
        }
        return forRet;
    }
    private void getHighScores()
    {

    }

}
