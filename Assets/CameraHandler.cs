using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using System.Linq;

public class CameraHandler : MonoBehaviour
{

    public List<CameraPosition> gameCameraAttachmentObjects;
    private int currentCameraIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (XRSettings.isDeviceActive)
        {
            //don't delete it in case we want to handle switching from VR to no VR but it's probably too annoying
            Camera cam = this.GetComponent<Camera>();
            cam.enabled = false;
        } else
        {
            OVRCameraRig rig = this.GetComponent<OVRCameraRig>();
            rig.enabled = false;

            //not sure if these are necessary yet, or if they need to be deleted completely
            OVRManager manager = this.GetComponent<OVRManager>();
            manager.enabled = false;
            OVRHeadsetEmulator emulator = this.GetComponent<OVRHeadsetEmulator>();
            emulator.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GoToNextCameraPosition()
    {
        if(gameCameraAttachmentObjects.Count == 0)
        {
            Debug.LogError("game camera attachment objects list was empty!");
        }

        ++currentCameraIndex;
        if (currentCameraIndex > gameCameraAttachmentObjects.Count)
        {
            currentCameraIndex = 0;
        }

        List<CameraPosition> enabledCameras = gameCameraAttachmentObjects.Where((position, index) => position.cameraPositionEnabled && index >= currentCameraIndex).ToList();
        CameraPosition firstPosition = enabledCameras.FirstOrDefault();
        if(firstPosition != null)
        {
            this.transform.parent = firstPosition.transform;
        }   
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == (int)Scenes.Game)
        {
            this.GoToNextCameraPosition();
        }
    }
}
