using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

//alternative method of handling events - have a list of delegates here and send them all events. 
// simpler and reduces the risk of sending an event to a dead object or the wrong events, but also adds a lot of potentially useless method calls
//public interface IEventAcceptor
//{
//    void ReceivedEvent(EventType e);
//}

public class CustomEventHandler : MonoBehaviour
{
    private static CustomEventHandler _sharedInstance;
    public static CustomEventHandler sharedInstance
    {
        get
        {
            if (_sharedInstance == null)
            {
                _sharedInstance = GameObject.FindObjectOfType<CustomEventHandler>();
            }

            if (_sharedInstance == null)
            {
                Debug.LogError("tried getting the CustomEventHandler instance before it was created...");
            }

            return _sharedInstance;
        }
    }

    public enum EventType
    {
        changeCamera, strengthenLights, weakenLights, slowDown, speedUp, anyKeyPressed
    }

    [SerializeField]
    private InputAction changeCameraAction;
    [SerializeField]
    private InputAction strengthenLightsAction;
    [SerializeField]
    private InputAction weakenLightsAction;
    [SerializeField]
    private InputAction slowDownAction;
    [SerializeField]
    private InputAction speedUpAction;
    [SerializeField]
    private InputAction anyKeyAction;

    public void SubscribeToEvent(EventType type, Action callback)
    {
        switch (type)
        {
            case EventType.changeCamera:
                changeCameraAction.performed += context => callback();
                break;
            case EventType.strengthenLights:
                strengthenLightsAction.performed += context => callback();
                break;
            case EventType.weakenLights:
                weakenLightsAction.performed += context => callback();
                break;
            case EventType.slowDown:
                slowDownAction.performed += context => callback();
                break;
            case EventType.speedUp:
                speedUpAction.performed += context => callback();
                break;
            case EventType.anyKeyPressed:
                anyKeyAction.performed += context => callback();
                break;
        }
    }

    public void UnsubscribeFromEvent(EventType type, Action callback)
    {
		//TODO: currently you can't unsubscribe from these events ... need to store these actions in a dict or something (gross)
        switch (type)
        {
            case EventType.changeCamera:
                changeCameraAction.performed -= context => callback();
                break;
            case EventType.strengthenLights:
                strengthenLightsAction.performed -= context => callback();
                break;
            case EventType.weakenLights:
                weakenLightsAction.performed -= context => callback();
                break;
            case EventType.slowDown:
                slowDownAction.performed -= context => callback();
                break;
            case EventType.speedUp:
                speedUpAction.performed -= context => callback();
                break;
            case EventType.anyKeyPressed:
                anyKeyAction.performed -= context => callback();
                break;
        }
    }

    private void Awake()
    {
        //var action = new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>");
        //action.performed += OnAnyKeyAction;
        //action.Enable();

        changeCameraAction.performed += OnCameraChangeAction;
        strengthenLightsAction.performed += OnStrengthenLightsAction;
        weakenLightsAction.performed += OnWeakenLightsAction;
        slowDownAction.performed += OnSlowDownAction;
        speedUpAction.performed += OnSpeedUpAction;
        anyKeyAction.performed += OnAnyKeyAction;
    }

    private void OnEnable()
    {
        changeCameraAction.Enable();
        strengthenLightsAction.Enable();
        weakenLightsAction.Enable();
        slowDownAction.Enable();
        speedUpAction.Enable();
        anyKeyAction.Enable();
    }

    private void OnDisable()
    {
        changeCameraAction.Disable();
        strengthenLightsAction.Disable();
        weakenLightsAction.Disable();
        slowDownAction.Disable();
        speedUpAction.Disable();
        anyKeyAction.Disable();
    }

    void OnCameraChangeAction(InputAction.CallbackContext context)
    {
        Debug.Log("change camera action");
    }

    void OnStrengthenLightsAction(InputAction.CallbackContext context)
    {
        Debug.Log("strengthen lights action");
    }

    void OnWeakenLightsAction(InputAction.CallbackContext context)
    {
        Debug.Log("weaken lights action");
    }

    void OnSlowDownAction(InputAction.CallbackContext context)
    {
        Debug.Log("slow down action");
    }

    void OnSpeedUpAction(InputAction.CallbackContext context)
    {
        Debug.Log("speed up action");
    }

    void OnAnyKeyAction(InputAction.CallbackContext context)
    {

        Debug.LogWarning("pressed any key");
    }
}