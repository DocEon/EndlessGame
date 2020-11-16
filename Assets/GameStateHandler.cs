using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    public QuadScript script;
    public CanvasFader canvasFader;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        CustomEventHandler.sharedInstance.SubscribeToEvent(CustomEventHandler.EventType.anyKeyPressed, AnyKeyPressed);
    }

    private void AnyKeyPressed()
    {
        if (gameStarted)
        {
            return;
        }

        gameStarted = true;
        CustomEventHandler.sharedInstance.UnsubscribeFromEvent(CustomEventHandler.EventType.anyKeyPressed, AnyKeyPressed);

        canvasFader.FadeOut(FadeOutFinished);
    }

    private void FadeOutFinished()
    {
		script.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
