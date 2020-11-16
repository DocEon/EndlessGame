using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateController : MonoBehaviour {

    private float controllerDeadzone = 0.3f;

    // Use this for initialization
    void Start ()
    { 
        
    }



    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -1 * controllerDeadzone)
        //    transform.Rotate(-Vector3.up * 200 * Time.deltaTime);
        //else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Vertical") > controllerDeadzone)
        //    transform.Rotate(Vector3.up * 200 * Time.deltaTime);
    }
}
