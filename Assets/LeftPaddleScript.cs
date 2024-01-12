using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleScript : MonoBehaviour
{
    public float moveSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-12, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.y < 11 && Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed;
        }
        
        if(transform.position.y > -11 && Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.up * moveSpeed;
        }
        
    }
}
