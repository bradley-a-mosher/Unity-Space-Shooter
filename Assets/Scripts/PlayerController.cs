using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //-------------------------------------
    private Rigidbody ThisBody = null;
    private Transform ThisTransform = null;

    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";

    public float MaxSpeed = 5f;
    public float ReloadDelay = 0.3f;
    public bool CanFire = true;

    public Transform[] TurretTransforms;

    //-------------------------------------
    void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
    }

    //-------------------------------------
    void FixedUpdate()
    {
        //Update movement
        //Mobile Code
        /*float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float Vert = CrossPlatformInputManager.GetAxis("Vertical");*/
        //keyboard controlls
        float Horz = Input.GetAxis(HorzAxis);
        float Vert = Input.GetAxis(VertAxis);
        Vector3 MoveDirection = new Vector3(Horz, 0f, Vert);
        ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);

        //Clamp speed
        ThisBody.velocity = new Vector3
            (Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
             Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed),
             Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed, MaxSpeed));

        //should look with mouse
        if(MouseLook)
        {
            //Update rotation - turn to face mouse pointer
            //Keyboard controlls
             Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                 Input.mousePosition.y, 0.0f));
             MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);

             //Get direction to cursor
             Vector3 LookDirection = MousePosWorld - ThisTransform.position;

             //FixedUpdate rotation
             ThisTransform.localRotation = Quaternion.LookRotation(LookDirection.normalized, Vector3.up);
            //Mobile Code
             
            //ThisTransform.localRotation = Quaternion.LookRotation(MoveDirection.normalized, Vector3.up);

            bool fireButton = CrossPlatformInputManager.GetButton("Fire");
        }

        //Check fire control
        /*Spacebar is used for mobile controls to shoot
        if(Input.GetKeyDown(KeyCode.Space)&&CanFire)
        {
            foreach (Transform T in TurretTransforms)
                AmmoManager.SpawnAmmo(T.position, T.rotation);

            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
        }
        */
        if (Input.GetButtonDown(FireAxis) && CanFire)
        {
            foreach (Transform T in TurretTransforms)
                AmmoManager.SpawnAmmo(T.position, T.rotation);

            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
        }
    }
    

    //--------------------------------
    void EnableFire()
    {
        CanFire = true;
    }
    //-------------------------------
    public void Die()
    {
        Destroy(gameObject);
    }
}
