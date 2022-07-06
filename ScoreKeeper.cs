using System;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour{
    private int score;
    private int coins;
    static ScoreKeeper instance;
    public static int coinsCollected;
    public int highScore;
    void Awake(){
        ManageSingleton();
    }

    void ManageSingleton(){
        if(instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start(){
        coinsCollected = PlayerPrefs.GetInt("Coins");
        highScore = PlayerPrefs.GetInt("HighScore");
        score = 0;
        coins = 0;
    }
    public int getScore(){
        return score;
    }

    public void modifyScore(int s){
        score = s;
    }

    public int getCoins(){
        return coins;
    }

    public void modifyCoins(int c){
        coins += c;
    }
    public void resetScore(){
        score = 0;
        coins = 0;
    }
    public void loadScores(){
        highScore = PlayerPrefs.GetInt("HighScore");
        coinsCollected += coins;
        if(score > highScore){
            PlayerPrefs.SetInt("HighScore", score);
        }
        PlayerPrefs.SetInt("Coins", coinsCollected);
        PlayerPrefs.Save();
    }

}
