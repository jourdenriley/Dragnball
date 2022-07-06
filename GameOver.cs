using UnityEngine;
using TMPro;
public class GameOver : MonoBehaviour{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinText;
    ScoreKeeper scoreKeeper;
    void Awake(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start(){
        scoreText.text = scoreKeeper.getScore().ToString("0000");
        coinText.text = scoreKeeper.getCoins().ToString("000");
    }

}
