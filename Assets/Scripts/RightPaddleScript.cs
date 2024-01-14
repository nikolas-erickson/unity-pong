using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddleScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(12, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.y < 11 && Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("going up");
            transform.position += Vector3.up * moveSpeed;
        }
        
        if(transform.position.y > -11 && Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= Vector3.up * moveSpeed;
        }
        
    }
}
