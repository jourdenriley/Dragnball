using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour{
    Player player;
    GameObject gameManager;
    ScoreKeeper scoreKeeper;

    public bool passed = false;
    public bool hasBeenHit = false;
    float obstacleHeight = .25f;
    float speed = 1f;

    void Awake(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        player = FindObjectOfType<Player>();
    }
    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("manager");
        speed = gameManager.GetComponent<GameManager>().GetSpeed();
    }

    void Update(){
        Move();
        Die();
        Score();
        
    }
    void Die(){ if (transform.position.y <= -5.5) Destroy(gameObject); }
    
    void Move(){ transform.Translate(0, -speed * Time.deltaTime, 0); }
    
    void Score(){
        if(player.transform.position.y > (transform.position.y + obstacleHeight) && passed == false){
            passed = true;
            //scoreKeeper.modifyScore(1);
        }
    }
    void OnCollisionExit2D(Collision2D col){
        // if(col.gameObject.tag == "player"){
        //     if(player.transform.position.y > (transform.position.y + obstacleHeight)){
        //         hasBeenHit = true;
        //         Debug.Log("hit");
        //     }
        // }
        
    }

}
