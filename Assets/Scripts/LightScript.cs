using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {
    public Light lt;
	// Use this for initialization
	void Start () {
        //just did this in the editor instead
        //lt = GetComponent<Light>();

        CustomEventHandler.sharedInstance.SubscribeToEvent(CustomEventHandler.EventType.strengthenLights, StrengthenLights);
        CustomEventHandler.sharedInstance.SubscribeToEvent(CustomEventHandler.EventType.weakenLights, WeakenLights);
	}

    private void OnDisable()
    {
        CustomEventHandler.sharedInstance.UnsubscribeFromEvent(CustomEventHandler.EventType.strengthenLights, StrengthenLights);
        CustomEventHandler.sharedInstance.UnsubscribeFromEvent(CustomEventHandler.EventType.weakenLights, WeakenLights);
    }

    private IEnumerator ChangeLightsCoroutine(bool strengthen)
    {
        var totalAnimationTime = 1.25f;
        var lightIntensityChange = 2f;
        var lightIntensityStart = lt.intensity;
        var lightIntensityGoal = lightIntensityStart + (strengthen ? lightIntensityChange : -lightIntensityChange);
        var elapsedTime = 0f;
        while (elapsedTime < totalAnimationTime)
        {
            elapsedTime += Time.deltaTime;
            var t = elapsedTime / totalAnimationTime;
            //smooth in/out
            t = t * t * (3f - 2f * t);
            lt.intensity = Mathf.Lerp(lightIntensityStart, lightIntensityGoal, t);

            if (lt.intensity >= 10) {
                lt.intensity = 10;
                yield break;
            }

            if (lt.intensity <= 0)
            {
                lt.intensity = 0;
                yield break;
            }

            yield return null;
        }
    }

    private void StrengthenLights()
    {
        StopAllCoroutines();
        StartCoroutine("ChangeLightsCoroutine", true);
    }

    private void WeakenLights()
    {
        StopAllCoroutines();
        StartCoroutine("ChangeLightsCoroutine", false);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButtonDown("LightDown"))
        //{
        //    print("Lights down");
        //    if (lt.intensity > 0)
        //    {
        //        lt.intensity -= .5f;
        //    }
        //}
        //if (Input.GetButtonDown("LightUp"))
        //{
        //    if (lt.intensity < 8)
        //    {
        //        lt.intensity += .5f;
        //    }

        //}
    }
}
