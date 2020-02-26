using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class restartGame : MonoBehaviour {

    Button myButton;

    // Use this for initialization
    void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() => { RestartGame(); });
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
