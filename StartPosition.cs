using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour{
    float speed = 1f;

    void Update(){
        Move();
    }
    void Move(){ transform.Translate(0, -speed * Time.deltaTime, 0); }
}
