using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    private enum Screen
    {
        eTitleScreen,
        eEndScreen,
        eGameScreen,
        ePauseScreen
    }
    private Screen currentScreen;
    public Canvas titleScreen;
    public Canvas playScreen;
    public Canvas pauseScreen;
    public Canvas endScreen;
    public GameObject rightPaddle;
    public GameObject leftPaddle;
    public GameObject ball;
    public GameObject net;
    public Text player0Score;
    public Text player1Score;
    [SerializeField] private LeftPaddleScript leftPaddleScript;
    private int[] score;
    private bool isPlaying;
    private bool isPaused;
    private int numPlayers;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
        isPaused = false;
        currentScreen = Screen.eTitleScreen;
        changeScreen(currentScreen);
        score = new int[2];
        leftPaddleScript = leftPaddle.GetComponent<LeftPaddleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //keys for pause and exit
        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            quitGame();
        }
        
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame(int nPlayers)
    {
        isPlaying = true;
        numPlayers = nPlayers;
        if(numPlayers == 1)
        {
            leftPaddleScript.enableSinglePlayerMode();
        }
        else if(numPlayers == 2)
        {
            leftPaddleScript.enableTwoPlayerMode();
        }
        changeScreen(Screen.eGameScreen);
        score[0] = score[1] = -1;
        addPoint(0);
        addPoint(1);
    }

    public void endGame()
    {
        changeScreen(Screen.eEndScreen);
    }

    public void goToTitleScreen()
    {
        changeScreen(Screen.eTitleScreen);
    }

    public void pauseGame()
    {
        if(isPlaying && !isPaused)
        {
            isPaused = true;
            changeScreen(Screen.ePauseScreen);
        }
        else if(isPlaying) //  && isPaused
        {
            isPaused = false;
            changeScreen(Screen.eGameScreen);
        }
    }

    private void changeScreen(Screen newScreen)
    {
        if(newScreen == Screen.eTitleScreen)
        {
            Debug.Log("Launching Title Screen.");
            titleScreen.enabled = true;
            pauseScreen.enabled = false;
            playScreen.enabled = false;
            showGameElements(false);
            endScreen.enabled = false;
        }
        else if (newScreen == Screen.eGameScreen)
        {
            Debug.Log("Launching Game Screen.");
            titleScreen.enabled = false;
            pauseScreen.enabled = false;
            playScreen.enabled = true;
            showGameElements(true);
            endScreen.enabled = false;
        }
        else if (newScreen == Screen.eEndScreen)
        {
            Debug.Log("Launching End Screen.");
            titleScreen.enabled = false;
            pauseScreen.enabled = false;
            playScreen.enabled = false;
            showGameElements(false);
            endScreen.enabled = true;
        }
        else if (newScreen == Screen.ePauseScreen)
        {
            Debug.Log("Launching Pause Screen.");
            titleScreen.enabled = false;
            pauseScreen.enabled = true;
            playScreen.enabled = false;
            showGameElements(false);
            endScreen.enabled = false;
        }
    }

    private void showGameElements(bool show)
    {
        rightPaddle.SetActive(show);
        leftPaddle.SetActive(show);
        ball.SetActive(show);
        net.SetActive(show);
    }

    public void addPoint(int playerNumber)
    {
        score[playerNumber] += 1;
        if(playerNumber == 0)
        {
            //set score player 1
            player0Score.text = score[playerNumber].ToString();
        }
        else
        {
            //set score player 2
            player1Score.text = score[playerNumber].ToString();
        }
        if(score[playerNumber] == 10)
        {
            changeScreen(Screen.eEndScreen);
        }
    }
}
