using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using System.Linq;

public class CameraHandler : MonoBehaviour {

	public List<CameraPosition> gameCameraAttachmentObjects;
	private int currentCameraIndex = 0;
	private CameraPosition currentCameraPosition;

	// Start is called before the first frame update
	void Start() {
		if (XRSettings.isDeviceActive) {
			//don't delete it in case we want to handle switching from VR to no VR but it's probably too annoying
			Camera cam = this.GetComponent<Camera>();
			cam.enabled = false;
		} else {
			OVRCameraRig rig = this.GetComponent<OVRCameraRig>();
			rig.enabled = false;

			//not sure if these are necessary yet, or if they need to be deleted completely
			OVRManager manager = this.GetComponent<OVRManager>();
			manager.enabled = false;
			OVRHeadsetEmulator emulator = this.GetComponent<OVRHeadsetEmulator>();
			emulator.enabled = false;
		}

		//TODO: previous + next camera
		CustomEventHandler.sharedInstance.SubscribeToEvent(CustomEventHandler.EventType.changeCamera, GoToNextCameraPosition);
	}

	// Update is called once per frame
	void Update() {
		if (currentCameraPosition != null && !currentCameraPosition.cameraPositionEnabled) {
			GoToNextCameraPosition();
		}
	}

	private void GoToNextCameraPosition() {
		if (gameCameraAttachmentObjects.Count == 0) {
			Debug.LogError("game camera attachment objects list was empty!");
			return;
		}

		List<CameraPosition> enabledCameras = gameCameraAttachmentObjects.Where((position, index) => position.cameraPositionEnabled).ToList();
		if (enabledCameras.Count == 0) {
			Debug.LogError("no valid camera positions!");
			return;
		} else if (enabledCameras.Count == 1) {
			return;
		}

		CameraPosition positionToGoTo = null;

		int startingPos = currentCameraIndex;
		do {
			++currentCameraIndex;
			if (currentCameraIndex >= gameCameraAttachmentObjects.Count) {
				currentCameraIndex = 0;
			}

			CameraPosition pos = gameCameraAttachmentObjects[currentCameraIndex];
			if (pos.cameraPositionEnabled) {
				positionToGoTo = pos;
				break;
			}
		} while (startingPos != currentCameraIndex);

		if (positionToGoTo != null) {
			currentCameraPosition = positionToGoTo;
			this.transform.parent = positionToGoTo.transform;
			this.transform.localPosition = Vector3.zero;
			this.transform.localRotation = Quaternion.identity;
		}
	}

	private void OnLevelWasLoaded(int level) {
		if (level == (int)Scenes.Game) {
			this.GoToNextCameraPosition();
		}
	}
}
