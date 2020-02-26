using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchLevel : MonoBehaviour {

    Button myButton;

    // Use this for initialization
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() => { swapLevel(); });
    }

    void swapLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level1");
    }
}
