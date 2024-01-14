using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public bool started;
    public Vector3 velocity;
    float moveSpeed;
    private float timer;
    private float startDelay;
    public GameLogicScript gameLogicManager;
    public int screenTop = 10;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ball.start()");
        transform.position = new Vector3(0,0,0);
        velocity = new Vector3(1,0,0);
        started = false;
        startDelay = .5f;
        moveSpeed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            if(transform.position.x < -21)
            {
                //point to player 1
                gameLogicManager.addPoint(1);
                resetBall(1);
            }
            else if (transform.position.x > 21)
            {
                //point to player 0
                gameLogicManager.addPoint(0);
                resetBall(0);
            }
            if(transform.position.y < 0-screenTop || transform.position.y > screenTop)
            {
                velocity.y = 0 - velocity.y;
            }

            transform.position += velocity * moveSpeed;
        }
        else
        {
            if(timer < startDelay)
            {
                timer += Time.deltaTime;
            }
            else
            {
                started = true;
            }
        }
    }

    private void resetBall(int servingTo)
    {
        int spawnRangeTop = screenTop;
        int spawnRangeBottom = 0;
        Start();
        velocity = new Vector3((1-servingTo*2),-0.25f,0);
        transform.position = new Vector3(0, Random.Range(spawnRangeTop, spawnRangeBottom));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        float xVel = 0 - velocity.x;
        float yVel = transform.position.y - other.transform.position.y;
        velocity = new Vector3(0-velocity.x, yVel);
    }
}
