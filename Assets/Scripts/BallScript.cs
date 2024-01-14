using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public bool started;
    public Vector3 velocity;
    float moveSpeed;
    private float timer;
    private float startDelay;
    private float speedModifier = 60f;
    public GameLogicScript gameLogicManager;
    public int screenTop = 10;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ball.start()");
        transform.position = new Vector3(0,0,0);
        velocity = Vector3.right * speedModifier;
        started = false;
        startDelay = 2f;
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
            if(transform.position.y < 0-screenTop)
            {
                velocity.y = math.abs(velocity.y);
            }
            else if (transform.position.y > screenTop)
            {
                velocity.y = -math.abs(velocity.y);
            }

            transform.position += velocity * moveSpeed * Time.deltaTime;
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
        velocity = new Vector3((1-servingTo*2),-0.25f,0) * speedModifier;
        transform.position = new Vector3(0, UnityEngine.Random.Range(spawnRangeTop, spawnRangeBottom));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        float xVel = 0 - velocity.x;
        float yVel = (transform.position.y - other.transform.position.y)*speedModifier;
        velocity = new Vector3(0-velocity.x, yVel);
    }
}
