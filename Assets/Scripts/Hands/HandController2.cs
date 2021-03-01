using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController2 : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private string controllerName;
    [SerializeField] private string actionTrigger;
    [SerializeField] private string actionGrip;

    private InputActionMap _actionMap;
    private InputAction _inputActionTrigger;
    private InputAction _inputActionGrip;

    private Animator _handAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        _actionMap = actionAsset.FindActionMap(controllerName);
        _inputActionGrip = _actionMap.FindAction(actionGrip);
        _inputActionTrigger = _actionMap.FindAction(actionTrigger);

        _handAnimator = GetComponent<Animator>();
    }

    void onEnable()
    {
        _inputActionGrip.Enable();
        _inputActionTrigger.Enable();
    }

   void onDisable()
    {
        _inputActionGrip.Disable();
        _inputActionTrigger.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        var gripValue = _inputActionGrip.ReadValue<float>();
        var triggerValue = _inputActionTrigger.ReadValue<float>();

        _handAnimator.SetFloat("Grip", gripValue);
        _handAnimator.SetFloat("Trigger", triggerValue);        

    }
}
