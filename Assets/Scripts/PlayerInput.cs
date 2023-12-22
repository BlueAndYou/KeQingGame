using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }
    InputManager inputActions;
    public event EventHandler OnNormalAttack;
    public event EventHandler OnSkillOne;
    public event EventHandler OnSkillTwo;
    public event EventHandler OnInteraction;

    public event EventHandler OnOpenBag;

    public event EventHandler OnSetting;
    
    private void Awake()
    {
        Instance = this;
        inputActions = new InputManager();
        inputActions.Player.Enable();
        inputActions.Player.RightMouse.performed += RightMouse_performed;
        inputActions.Player.SkillOne.performed += SkillOne_performed;
        inputActions.Player.SkillTwo.performed += SkillTwo_performed;
        inputActions.Player.Interaction.performed += Interaction_performed;
        inputActions.Player.OpenBag.performed += OpenBag_performed;
        inputActions.Player.Setting.performed += Setting_performed;

    }

    private void Setting_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSetting?.Invoke(this, EventArgs.Empty);
    }

    private void OpenBag_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOpenBag?.Invoke(this, EventArgs.Empty);
    }

    private void Interaction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteraction?.Invoke(this, EventArgs.Empty);
    }

    private void SkillTwo_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        OnSkillTwo?.Invoke(this, EventArgs.Empty);
    }

    private void SkillOne_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSkillOne?.Invoke(this, EventArgs.Empty);

    }


    private void RightMouse_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnNormalAttack?.Invoke(this, EventArgs.Empty);
    }
    private void OnDestroy()
    {
        inputActions.Player.RightMouse.performed -= RightMouse_performed;
        inputActions.Player.SkillOne.performed -= SkillOne_performed;
        inputActions.Player.SkillTwo.performed -= SkillTwo_performed;
        inputActions.Player.Interaction.performed -= Interaction_performed;
        inputActions.Player.OpenBag.performed -= OpenBag_performed;
        inputActions.Disable();
    }
}
