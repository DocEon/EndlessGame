using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    public bool cameraPositionEnabled
    {
        get
        {
            ActorScripts script = this.GetComponentInParent<ActorScripts>();
            if(script != null)
            {
                return script.isRunning;
            }

            return true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
