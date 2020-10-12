using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorScripts : MonoBehaviour {
    public bool isRunning = false;
    public Vector3 nextStep = new Vector3();
    public Vector3 lastStep = new Vector3(0, 0, 0);
    public int rotationState = 0;
	private Animator animator;
    // Use this for initialization
    void Start () {
		animator = GetComponent<Animator>();
		if (animator == null) {
			Debug.LogError("couldn't find animator for actor! this is bad!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LeftFootfall() {
		if (isRunning) {
			//left footfall: play sound
			Debug.Log("step left");
		}
	}

	void RightFootfall() {
		if (isRunning) {
			//right footfall: play sound
			Debug.Log("step right");
		}
	}
}
