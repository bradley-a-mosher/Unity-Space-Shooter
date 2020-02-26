using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    //Game Score
    public static int Score;
    public static int temp;
    
    //Prefix
    public string ScorePrefix = string.Empty;

    Scene scene;

    //Score text object
    public Text ScoreText = null;

    //Game over text
    public Text GameOverText = null;

    public static GameController ThisInstance = null;
	// Use this for initialization
	void Awake () {
        ThisInstance = this;
        scene =  SceneManager.GetActiveScene();
        Debug.Log(scene.path);

    }


    // Update is called once per frame
    void Update()
    {
        //Update score text
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }

        if(temp == 2 && scene.path == "Assets/Scenes/level1.unity")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("level2");
        }
        else if(temp == 5 && scene.path == "Assets/Scenes/level2.unity")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("level3");
        }
        else if(temp == 10 && scene.path == "Assets/Scenes/level3.unity")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("level4");
        }
        else if(temp == 15 && scene.path == "Assets/Scenes/level4.unity")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("level5");
        }
 
    }

    



    public static void GameOver()
    {
        if (ThisInstance.GameOverText != null)
            ThisInstance.GameOverText.gameObject.SetActive(true);
    }
}
