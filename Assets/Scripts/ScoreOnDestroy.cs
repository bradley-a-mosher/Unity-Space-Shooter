using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour {

    public int ScoreValue = 50;
    public int x = 1;
	
    void OnDestroy()
    {
        if (gameObject.tag.Equals("Enemy"))
        {
            GameController.Score += ScoreValue;
            GameController.temp += x;
        }
           
       
    }

}
