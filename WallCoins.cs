using UnityEngine;

public class WallCoins : MonoBehaviour{

    float speed = 1f;
    ScoreKeeper scoreKeeper;
    GameManager gameManager;
    void Awake(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start(){
        speed = gameManager.GetComponent<GameManager>().GetSpeed();
    }
    void Update(){
        Move();
        Die();   
    }
    void Die(){ if (transform.position.y <= -5.5) Destroy(gameObject); }
    
    void Move(){ transform.Translate(0, -speed * Time.deltaTime, 0); }
    
    
}