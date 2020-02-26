using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class pauseGame : MonoBehaviour {

    Button myButton;
    public GameObject menu;
    bool showMenu;
    int timeToggle;

    // Use this for initialization
    void Start()
    {
        timeToggle = 1;
        showMenu = false;
        menu.SetActive(showMenu);
    }

    void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() => { pauseMenu(); });
    }

    void pauseMenu()
    {
        showMenu = !showMenu;

        menu.SetActive(showMenu);

        if (showMenu)
        {
            timeToggle = 0;
        }
        else
        {
            timeToggle = 1;
        }

        Time.timeScale = timeToggle;
    }
}
