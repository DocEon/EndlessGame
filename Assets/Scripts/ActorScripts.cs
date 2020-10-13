using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorScripts : MonoBehaviour {
	private bool _isRunning = true;
	public bool isRunning {
		get {
			return _isRunning;
		}
	}
    public Vector3 nextStep = new Vector3();
	public AnimatorScript animatorScript;
	private AudioSource musicAudioSource;

    //public Vector3 lastStep = new Vector3(0, 0, 0);
    public int rotationState = 0;

	public void StartTurning() {
		animatorScript.isTurning = true;
	}

	public void StopTurning() {
		animatorScript.isTurning = false;
	}

	public void StartRunningTowards(Vector3 nextStep) {
		_isRunning = true;
		this.nextStep = nextStep;
		animatorScript.StartAnimating();

		if (musicAudioSource != null) {
			musicAudioSource.Play();
		}
	}

	public void StopRunning() {
		_isRunning = false;
		animatorScript.StopAnimating();

		if (musicAudioSource != null) {
			musicAudioSource.Pause();
		}
	}

    // Use this for initialization
    void Start () {
		musicAudioSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
