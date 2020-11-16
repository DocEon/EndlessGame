using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour {
    Random r = new Random();
	public int pace = 0;
	private bool isAnimating = false;
    public bool isTurning = false;
    string walkname = "walk";
	private Animator animator;
	private AudioSource audioSource;

	private string[] audioSources = new string[] { "footfall", "footfall2", "footfall3", "footfall4", "footfall5", "footfall6" };

	public void StartAnimating() {
		isAnimating = true;
	}

	public void StopAnimating() {
		isAnimating = false;
	}
	// maybe an angle needs to go here?
	// Use this for initialization
	// next to do - set turning animation based on which direction they're moving. so mirror if it's theo ther way.
	void Start () {
        isTurning = false;
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		if (animator == null) {
			Debug.LogError("couldn't find animator for actor! this is bad!");
		}

		if (transform.name == "Red")
        {
            Random.InitState(1);
        }
        else if (transform.name == "Blue")
        {
            Random.InitState(2);
        }
        else if (transform.name == "White")
        {
            Random.InitState(3);
        }
        else if (transform.name == "Yellow")
        {
            Random.InitState(4);
        }
	}
	
	// Update is called once per frame
	void Update () {
    //    if (Input.GetButtonDown("WalkSwap"))
    //    {
    //        print("command recevied");
    //        if (walkname == "walk") // max
    //        {
    //            walkname = "walk2";
    //        }
    //        else walkname = "walk";
    //    }
    //    anim.SetInteger("walk", pace);
    //    if (isTurning && !anim.GetBool("turning"))
    //    {
    //        anim.Play("turnright");
    //        print("Turning set to" + anim.GetBool("turning"));
    //    }
    //    else if (!isTurning && anim.GetBool("turning"))
    //    {
    //        anim.Play(walkname);
    //        print("Turning set to" + anim.GetBool("turning"));
    //    }
    //    else anim.Play(walkname);
    }

	void PlayFootstepClip() {
		//if (audioSource.isPlaying) {
		//	return;
		//}

		int rand = Random.Range(0, audioSources.Length);
		string str = audioSources[rand];
		AudioClip clip = Resources.Load(str) as AudioClip;
		audioSource.PlayOneShot(clip);
	}

	void LeftFootfall() {
		if (isAnimating) {
			PlayFootstepClip();
		}
	}

	void RightFootfall() {
		if (isAnimating) {
			PlayFootstepClip();
		}
	}
}
