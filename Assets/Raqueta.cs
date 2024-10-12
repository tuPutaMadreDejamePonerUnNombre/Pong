using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By Javier Garcia Palacio
public class MoverRaqueta : MonoBehaviour {
    public float speed = 30;
    public string axis = "Vertical";
    void FixedUpdate () {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;

    }

    void Update()
    {
        
    }
}