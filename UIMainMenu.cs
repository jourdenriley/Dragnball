using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMainMenu : MonoBehaviour{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI coinsCollectedText;


    void Start(){
        highScoreText.text =  PlayerPrefs.GetInt("HighScore",0).ToString("0000");
        coinsCollectedText.text = PlayerPrefs.GetInt("Coins",0).ToString("000");

    }

    
    void Update(){
        
    }
}
