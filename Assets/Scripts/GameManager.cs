using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for text
using UnityEngine.SceneManagement; //for the PlayAgain function

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject gameOverPanelWin;
    public int numberBricks;
    public AudioClip _WinSound;
    

    // Start is called before the first frame update
    void Start()
    {
        
        livesText.text = "LIVES: " + lives;
        scoreText.text = "SCORE: " + score;
        numberBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int ChangeInLives)
    {
    //be able to increment or decrement lives:
        lives += ChangeInLives;

        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "LIVES: " + lives;
    }

    public void UpdateScore(int ChangeinScore)
    {
        score += ChangeinScore;
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateNumberofBricks()
    {
        numberBricks--;
        if(numberBricks <= -2)
        {
            AudioSource.PlayClipAtPoint(_WinSound, transform.position);
            GameOverWin();
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    void GameOverWin()
    {
        
        gameOver = true;
        gameOverPanelWin.SetActive(true);
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync("Main");
        Debug.Log("Play Again");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit"); //just to see it works
    }
}
