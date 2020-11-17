using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {
    public Light lt;
	// Use this for initialization
	void Start () {
        lt = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("LightDown"))
        {
            print("Lights down");
            if (lt.intensity > 0)
            {
                lt.intensity -= .5f;
            }
        }
        if (Input.GetButtonDown("LightUp"))
        {
            if (lt.intensity < 8)
            {
                lt.intensity += .5f;
            }

        }
    }
}
