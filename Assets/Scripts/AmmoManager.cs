﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour {

    //---------------------
    //Reference to ammo prefab
    public GameObject AmmoPrefab = null;

    //Ammo pool count
    public int PoolSize = 100;

    public Queue<Transform> AmmoQueue = new Queue<Transform>();

    //Array of ammo obects to generate
    private GameObject[] AmmoArray;

    public static AmmoManager AmmoManagerSingleton = null;
    //-----------------------------
    //Use this for initialization
    void Awake()
    {
        if (AmmoManagerSingleton != null)
        {
            Destroy(GetComponent < AmmoManager>() );
            return;
        }

        AmmoManagerSingleton = this;
        AmmoArray = new GameObject[PoolSize];

        for (int i = 0; i < PoolSize; i++)
        {
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            Transform ObjTranform = AmmoArray[i].GetComponent<Transform>();
            ObjTranform.parent = GetComponent<Transform>();
            AmmoQueue.Enqueue(ObjTranform);
            AmmoArray[i].SetActive(false);
        }
    }
    //------------------------------------
    public static Transform SpawnAmmo(Vector3 Position, Quaternion Rotation)
    {
        //Get ammo
        Transform SpawnedAmmo = AmmoManagerSingleton.AmmoQueue.Dequeue();
        SpawnedAmmo.gameObject.SetActive(true);
        SpawnedAmmo.position = Position;
        SpawnedAmmo.localRotation = Rotation;

        //Add to queue end
        AmmoManagerSingleton.AmmoQueue.Enqueue(SpawnedAmmo);

        //Return ammo
        return SpawnedAmmo;
    }
}
