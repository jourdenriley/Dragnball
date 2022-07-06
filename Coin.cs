using UnityEngine;

public class Coin : MonoBehaviour{
    ScoreKeeper scoreKeeper;
    AudioPlayer audioPlayer;
    GameManager gameManager;

    void Awake(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Update(){
        Die();
    }

    void OnTriggerEnter2D(Collider2D col){
        scoreKeeper.modifyCoins(1);
        audioPlayer.PlayCoinClip();
        Destroy(gameObject);
    }

    void Die(){ if (transform.position.y <= -5.5) Destroy(gameObject); }
}
