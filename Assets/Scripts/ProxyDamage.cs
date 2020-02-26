using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour {

    //----------------------------
    //Damage per second
    public float DamageRage = 10f;
    //----------------------------
    void OnTriggerStay(Collider Col)
    {
        Health H = Col.gameObject.GetComponent<Health>();

        if (H == null) return;

        H.HealthPoints -= DamageRage * Time.deltaTime;
    }
    //----------------------------

}
