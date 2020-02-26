using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemies : MonoBehaviour {

    public float countdown = 30f;
    private bool timerStarts = false;
    public GameObject DeathParticlesPrefab = null;
    private Transform ThisTransform = null;
    public bool ShouldDestroyOnDeath = true;

    // Use this for initialization
    void Start()
    {
        this.gameObject.active = false;
        InvokeRepeating("Spawn", 5f, 45f);
    }

    void Update()
    {
        if (timerStarts)
        {
            countdown -= Time.deltaTime * 1.25f;
            if (countdown <= 0)
            {
                countdown = 30f;
                timerStarts = false;
                Time.timeScale = 1f;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy"); 
        if (col.tag == "Player")
        {
            for(int i = 0; i < enemy.Length; i++)
            {
                Destroy(enemy[i]);
            }
            this.transform.position = new Vector3(-16f, 0f, 0f);
        }
    }

    void Spawn()
    {
        this.gameObject.active = true;
        this.transform.position = new Vector3(Random.Range(-8f, 8f), 0f, Random.Range(-4f, 4f));
    }
}
