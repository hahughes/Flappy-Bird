using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public static GameControl instance; //A reference to our game control script so we can access it statically.
    public Text scoreText;
    public GameObject gameOverText; //A reference to the object that displays the text which appears when the player dies.

    private int score = 0;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    // Start is called before the first frame update
    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if(instance != this)
            //...destroy this one because it is a duplicate.
            Destroy (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0)){
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
        }
    }

    public void BirdScored(){
        if(gameOver) return;
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
