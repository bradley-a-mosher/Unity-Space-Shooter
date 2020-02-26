using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowDownTime : MonoBehaviour {

    public float countdown = 30f;
    private bool timerStarts = false;
    
    // Use this for initialization
    void Start()
    {
        this.gameObject.active = false;
        InvokeRepeating("Spawn", 5f , 45f);
    }

    void Update()
    {
        if (timerStarts)
        {
            countdown -= Time.deltaTime * 1.25f;
            if(countdown <= 0)
            {
                countdown = 30f;
                timerStarts = false;
                Time.timeScale = 1f;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            timerStarts = true;
            Time.timeScale = .5f;
            this.transform.position = new Vector3(-14f, 0f, 0f);
        }
    }

    void Spawn()
    {
        this.gameObject.active = true;
        this.transform.position = new Vector3(Random.Range(-8f, 8f), 0f, Random.Range(-4f, 4f));
    }


}
