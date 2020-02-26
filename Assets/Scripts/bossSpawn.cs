using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawn : MonoBehaviour {

    public float MaxRadius = 1f;
    public float Interval = 10f;
    public GameObject ObjToSpawn = null;
    private Transform Origin = null;
    // Use this for initialization
    void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        InvokeRepeating("Spawn", 20f, Interval);
    }

    void Spawn()
    {
        if (Origin == null) return;

        Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
        Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
    }
}
