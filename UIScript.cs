using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinText;
    
    ScoreKeeper scoreKeeper;

    void Start(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Update(){
        scoreText.text = scoreKeeper.getScore().ToString("0000");
        coinText.text = scoreKeeper.getCoins().ToString("000");
    }
}
