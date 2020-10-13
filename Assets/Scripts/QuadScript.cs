﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScript : MonoBehaviour {
    // State is either 0 or 1. At 0, move counterclockwise; at 1, move across; at 2, currently moving.
    // todo: fix state management. Either nextstep has to get everyone's next step at once, which would be harder,
    // or nextstep is done in batches, with state-changes after new steps are assigned.

    // Handle entrances, exits, who's next in-program. Make it interactive by letting the user choose the next pattern.
    // Walking out is always done on a diagonal, 
    // Rotation states: 0 - walking; 1 - rotating 2 - done rotating;
    // todo: make people who need to exit rotate towards the exit and walk out, instead of rotating where they would if they were continuing.
    // todo: make it play the other turning animation when they're in the middle.
    public int rotationState = 0;
    public int state = 0;
    public Transform Red;
    public Transform Yellow;
    public Transform White;
    public Transform Blue;
    private bool nextState = true;
    private bool firstTime = true;
    private Vector3 A = new Vector3 (-4, 0, 4);
    private Vector3 B = new Vector3(4, 0, 4);
    private Vector3 C = new Vector3(-4, 0, -4);
    private Vector3 D = new Vector3(4, 0, -4);
    private Vector3 a = new Vector3(-1, 0, 1);
    private Vector3 b = new Vector3(1, 0, 1);
    private Vector3 c = new Vector3(-1, 0, -1);
    private Vector3 d = new Vector3(1, 0, -1);
    private Vector3 E = new Vector3(0, 0, 0);
    private Vector3 A1 = new Vector3(-1, -10, 1);
    private Vector3 B1 = new Vector3(-3, -10, 1);
    private Vector3 C1 = new Vector3(-5, -10, 1);
    private Vector3 D1 = new Vector3(-7, -10, 1);
    public float speed;
    public static List<Transform> actorList = new List<Transform>();
    private int howManyLaps = 0;
    private string currentSeries;
    private int currentSeriesIndex = -1;
	//24 total series, 1-23.

	private bool isGameRunning = false;
    
    string[] seriesArray = new string[] { "W", "WB", "WBR", "WBRY", "BRY", "BY", "Y", "YW", "YWR", "YWRB", "WRB", "RB", "B", "BY", "BYW", "BYWR", "YWR", "WR", "R", "RB", "RBY", "RYBW", "YBW", "BW", "W" };

    Vector3 GetNextStep (Vector3 currentPosition)
    {
        if (state == 0)
        {
            if (currentPosition == A)
            {
                return C;
            }
            else if (currentPosition == B)
            {
                return A;
            }
            else if (currentPosition == C)
            {
                return D;
            }
            else if (currentPosition == D)
            {
                return B;
            }
        }
        else if (state == 1)
        {
            if (currentPosition == A)
            {
                return a;
            }
            else if (currentPosition == B)
            {
                return b;
            }
            else if (currentPosition == C)
            {
                return c;
            }
            else if (currentPosition == D)
            {
                return d;
            }
        }
        else if (state == 2)
        {
            if (currentPosition == a)
            {
                return c;
            }
            else if (currentPosition == b)
            {
                return a;
            }
            else if (currentPosition == c)
            {
                return d;
            }
            else if (currentPosition == d)
            {
                return b;
            }
        }
        else if (state == 3)
        {
            if (currentPosition == a)
            {
                return C;
            }
            else if (currentPosition == b)
            {
                return A;
            }
            else if (currentPosition == c)
            {
                return D;
            }
            else if (currentPosition == d)
            {
                return B;
            }
        }
        {
            print("Error!" + currentPosition + state);
            return currentPosition;
        }
    }

	public void StartGame() {
		isGameRunning = true;
		White.position = A;
		White.GetComponent<ActorScripts>().StartRunningTowards(C);
		CustomEventHandler.sharedInstance.SubscribeToEvent(CustomEventHandler.EventType.speedUp, SpeedUp);
		CustomEventHandler.sharedInstance.SubscribeToEvent(CustomEventHandler.EventType.slowDown, SlowDown);
	}

    void Start () {
        Red = gameObject.transform.GetChild(0);
        Yellow = gameObject.transform.GetChild(1);
        White = gameObject.transform.GetChild(2);
        Blue = gameObject.transform.GetChild(3);
        actorList.Add(Red);
        actorList.Add(Yellow);
        actorList.Add(White);
        actorList.Add(Blue);
    }

	private void SpeedUp() {
		speed = speed * 1.5f;
		speed = Mathf.Min(100, speed);
	}

	private void SlowDown() {
		speed = speed / 1.5f;
		speed = Mathf.Max(0.1f, speed);
	}
	
	// Update is called once per frame
	void Update () {
        {
			if (!isGameRunning) {
				return;
			}
            //if (Input.GetKey("escape"))
            //    Application.Quit();
            //if (Input.GetButtonDown("SpeedUp"))
            //{
            //    if (speed < 100)
            //    {
            //        speed += 1;
            //    }
            //}
            //if (Input.GetButtonDown("SpeedDown"))
            //{
            //    if (speed > 1)
            //    {
            //        speed -= 1;
            //    }
                
            //}
            if (howManyLaps == 0)
            {
                currentSeriesIndex += 1;
                if (currentSeriesIndex == 24)
                {
                    currentSeriesIndex = 1;
                }
                currentSeries = seriesArray[currentSeriesIndex];
                if (currentSeries.IndexOf("W") != -1)
                {
                    White.position = A;
                    White.LookAt(C);    
                    if (!White.GetComponent<ActorScripts>().isRunning)
                    {
						White.GetComponent<ActorScripts>().StartRunningTowards(C);
                    }
                }
                if (currentSeries.IndexOf("B") != -1)
                {
                    Blue.position = C;
                    Blue.LookAt(D);
                    if (!Blue.GetComponent<ActorScripts>().isRunning)
                    {
                        Blue.GetComponent<ActorScripts>().StartRunningTowards(D);
                    }
                }
                if (currentSeries.IndexOf("Y") != -1)
                {
                    Yellow.position = B;
                    Yellow.LookAt(A);
                    if (!Yellow.GetComponent<ActorScripts>().isRunning)
                    {
                        Yellow.GetComponent<ActorScripts>().StartRunningTowards(A);
                    }
                }
                if (currentSeries.IndexOf("R") != -1)
                {
                    Red.position = D;
                    Red.LookAt(B);
                    if (!Red.GetComponent<ActorScripts>().isRunning)
                    {
						Red.GetComponent<ActorScripts>().StartRunningTowards(B);
                    }
                }
                if (White.GetComponent<ActorScripts>().isRunning && currentSeries.IndexOf("W") == -1)
                {
					White.GetComponent<ActorScripts>().StopRunning();
                    White.position = A1;
                }
                if (Yellow.GetComponent<ActorScripts>().isRunning && currentSeries.IndexOf("Y") == -1)
                {
					Yellow.GetComponent<ActorScripts>().StopRunning();
                    Yellow.position = B1;
                }
                if (Blue.GetComponent<ActorScripts>().isRunning && currentSeries.IndexOf("B") == -1)
                {
                    Blue.GetComponent<ActorScripts>().StopRunning();
                    Blue.position = C1;
                }
                if (Red.GetComponent<ActorScripts>().isRunning && currentSeries.IndexOf("R") == -1)
                {
                    Red.GetComponent<ActorScripts>().StopRunning();
                    Red.position = D1;
                }

                if (firstTime)
                {
                    howManyLaps = 5;
                    firstTime = false;
                }
                else
                {
                    howManyLaps = 4;
                }
            }
            if (nextState)
            {
                print("Nextstate trigggered. Debug: State = " + state + ", howManyLaps = " + howManyLaps + ".");
                if (state == 3)
                {
                    state = 0;
                }
                else if (state == 0)
                {
                    state += 1;
                    howManyLaps -= 1;
                }
                else
                {
                    state += 1;
                }
                nextState = false;
                for (int i = 0; i <= 3; i++)
                {
                    //actorList[i].LookAt(actorList[i].GetComponent<ActorScripts>().nextStep);
                }
            }
        }
        
        
	}
    private void LateUpdate()
    {
		if (!isGameRunning) {
			return;
		}
        float step = speed * Time.deltaTime;
        foreach (Transform actor in actorList)
        {
			ActorScripts actorScript = actor.GetComponent<ActorScripts>();
			Vector3 nextStep = actorScript.nextStep;

            if (actorScript.isRunning)
            {
                actor.position = Vector3.MoveTowards(actor.position, nextStep, step);

                if (actor.position == nextStep) // here's where we see we're on the next-step. next-state can't get called until we rotate.
                {
                    if (actorScript.rotationState == 0) // when we first hit the next step.
                    {
						// figure out the angle we need to turn towards. start rotating.
						actorScript.rotationState = 1;
                    }
                    else if (actorScript.rotationState == 1) // should be rotating
                    {
						// rotate
						// if is done rotating, then set rotationState = 2. Else rotate. 
						actorScript.StartTurning();
                        Vector3 relativePos = (GetNextStep(nextStep) - actor.position);
                        Quaternion rotation = Quaternion.LookRotation(relativePos);
                        actor.rotation = Quaternion.Lerp(actor.rotation, rotation, step*1.5f);
                        Vector3 dirFromAtoB = (GetNextStep(nextStep) - actor.position).normalized;
                        float dotProd = Vector3.Dot(dirFromAtoB, actor.forward);
                        
                        if (dotProd > 0.99)
                        {
                            actor.LookAt(nextStep);
							actorScript.rotationState = 2;   
                        }
                        
                    }
                    else if (actorScript.rotationState == 2) 
                    {
						//actorScript.lastStep = nextStep;
						actorScript.nextStep = GetNextStep(actor.position);
                       // actor.LookAt(actor.GetComponent<ActorScripts>().nextStep);
                        nextState = true;
						actorScript.StopTurning();
                        actor.position = Vector3.MoveTowards(actor.position, actorScript.nextStep, step);
						actorScript.rotationState = 0;
                    }
                }
            }
        }
    }
}
