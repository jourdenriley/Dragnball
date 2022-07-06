using UnityEngine;

public class Player : MonoBehaviour{

    Rigidbody2D rb;
    Vector2 dragStartPos;
    Vector2 dragReleasePos;
    
    float force = 3f;
    float maxForce = 10f;
    int currJump = 3;
    LevelManager levelManager;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    [SerializeField] Transform startPos;
    void Awake(){
        levelManager = FindObjectOfType<LevelManager>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        
    }
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    void Update(){
        
        float dist = Vector2.Distance(startPos.position, transform.position);
        if(dist >= scoreKeeper.getScore()){
            scoreKeeper.modifyScore(Mathf.RoundToInt(dist));
        }
        if(currJump > 0){
            if(Input.GetMouseButtonDown(0)) DragStart();
            if(Input.GetMouseButton(0)) Dragging();
            if(Input.GetMouseButtonUp(0)){
                Time.timeScale = 1;
                DragRelease();
            } 
        } 
    }

    void DragStart(){
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Dragging(){
        Vector2 dragReleasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _velocity = Vector3.ClampMagnitude((dragReleasePos - dragStartPos) * force, maxForce);
    }

    void DragRelease(){
        Vector2 dragRelease = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //audioPlayer.PlaySwipeClip();
        Vector2 _velocity = (dragRelease - dragStartPos) * force;
        
        if(_velocity.magnitude > maxForce) rb.velocity = Vector3.ClampMagnitude(_velocity, maxForce);
        else rb.velocity = _velocity;
        currJump--;
        if(currJump < 0){
            currJump = 0;
        }
    }

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps){
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;

        Vector2 gravityAccel = Physics2D.gravity * 1.0f * timestep * timestep;

        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; i++){
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "GameOver"){
            GetComponent<Player>().enabled = false;
            levelManager.LoadGameOver(); 
            }
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "ground"){
            audioPlayer.PlayBounceClip();
        }
        //if(col.gameObject.tag == "platform"){ // && ((col.transform.position.y + .25f) < transform.position.y)){
            // if(col.gameObject.GetComponent<Obstacle>().hasBeenHit == false&&
            //     col.transform.position.y < transform.position.y){
            //if(col.gameObject.GetComponent<Obstacle>().hasBeenHit == false){
                //Debug.Log("rest jumps");
        currJump = 3;
            //}
            
            //     Debug.Log("Jumps reset");
            // }
            
            
        //}
    }
}
