using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{   
    const float LEVEL_1 = 2F;
    const float LEVEL_2 = 3f;

    [Header("Obstacles")]
    [SerializeField] Transform[] obstacleSpawns;
    [SerializeField] GameObject[] basicObstacles;

    [Header("Coins")]
    [SerializeField] Transform[] wallSpawns;
    [SerializeField] GameObject wallCoins;
    [SerializeField] Transform _dynamic;
    private float speed = 1f;
    float spawnTime = LEVEL_2;
    ScoreKeeper scoreKeeper;
    public float GetSpeed(){
        return speed;
    }
    public void SetSpeed(float s){
        
        speed = s;
    }
    void Awake(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start(){
        StartCoroutine("SpawnObstacle");
        StartCoroutine("SpawnWallCoins");
    }
    IEnumerator SpawnObstacle(){
        while(true){
            int i = Random.Range(0, obstacleSpawns.Length);
            int j = Random.Range(0, basicObstacles.Length);
            Instantiate(basicObstacles[j], obstacleSpawns[i].position, Quaternion.identity, _dynamic);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    IEnumerator SpawnWallCoins(){
        while(true){
        int i = Random.Range(0, wallSpawns.Length);
        Instantiate(wallCoins, wallSpawns[i].position, Quaternion.identity, _dynamic);
        yield return new WaitForSeconds(11f);
        }
    }
    
}
