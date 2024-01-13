using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class LeftPaddleScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject ball;

    private bool aiMode;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-12, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!aiMode)
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
        else
        {
            if(transform.position.y < 11 && underBall())
            {
                transform.position += Vector3.up * moveSpeed;
            }
            
            if(transform.position.y > -11 && overBall())
            {
                transform.position -= Vector3.up * moveSpeed;
            }
        }
        
    }

    public void enableTwoPlayerMode()
    {
        aiMode = false;
    }

    public void enableSinglePlayerMode()
    {
        aiMode = true;
    }

    private bool underBall()
    {
        return transform.position.y<ball.transform.position.y;
    }

    private bool overBall()
    {
        return transform.position.y>ball.transform.position.y;
    }
}
