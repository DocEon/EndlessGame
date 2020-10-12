using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour {
    Animator anim;
    Random r = new Random();
    public int pace = 0;
    public bool isTurning = false;
    string walkname = "walk";
    // maybe an angle needs to go here?
    // Use this for initialization
    // next to do - set turning animation based on which direction they're moving. so mirror if it's theo ther way.
    void Start () {
        anim = GetComponent<Animator>();
        isTurning = false;

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

	void LeftFootfall() {
		//Debug.Log("left footstep");
	}

	void RightFootfall() {
		//Debug.Log("right footstep");
	}
}
