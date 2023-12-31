//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputManager.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputManager : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""622eab9c-f00f-40ab-b0e8-71a5626e4646"",
            ""actions"": [
                {
                    ""name"": ""RightMouse"",
                    ""type"": ""Button"",
                    ""id"": ""ce9a6377-eeae-4918-bef5-148873c5a062"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkillOne"",
                    ""type"": ""Button"",
                    ""id"": ""0282b433-53e5-4276-a4e7-31b14ee0ce60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkillTwo"",
                    ""type"": ""Button"",
                    ""id"": ""43f5c774-89e1-4475-8797-10e83389415e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""16d5bbc7-ab91-47ed-be4c-ba97f18a10d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenBag"",
                    ""type"": ""Button"",
                    ""id"": ""e1bf2ea7-b89a-41b7-b751-fa4b95ff811c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Setting"",
                    ""type"": ""Button"",
                    ""id"": ""d735e2d9-6735-4d92-93a5-796283e8ba46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dfe7cb19-5f1f-48e4-849c-ca063adeef9e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""538e2b66-aeeb-4d14-b7ab-7baa67d39034"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b76844a7-7b72-4c8c-92a4-549c839d0e0e"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4ec81bd-edd1-441f-b6d2-f3c2419c3fbb"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""834b7d33-6909-4a43-96ff-a752ad9f95b5"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenBag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4a266b7-1ced-4cc3-b365-083c9ae49ea5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Setting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_RightMouse = m_Player.FindAction("RightMouse", throwIfNotFound: true);
        m_Player_SkillOne = m_Player.FindAction("SkillOne", throwIfNotFound: true);
        m_Player_SkillTwo = m_Player.FindAction("SkillTwo", throwIfNotFound: true);
        m_Player_Interaction = m_Player.FindAction("Interaction", throwIfNotFound: true);
        m_Player_OpenBag = m_Player.FindAction("OpenBag", throwIfNotFound: true);
        m_Player_Setting = m_Player.FindAction("Setting", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_RightMouse;
    private readonly InputAction m_Player_SkillOne;
    private readonly InputAction m_Player_SkillTwo;
    private readonly InputAction m_Player_Interaction;
    private readonly InputAction m_Player_OpenBag;
    private readonly InputAction m_Player_Setting;
    public struct PlayerActions
    {
        private @InputManager m_Wrapper;
        public PlayerActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightMouse => m_Wrapper.m_Player_RightMouse;
        public InputAction @SkillOne => m_Wrapper.m_Player_SkillOne;
        public InputAction @SkillTwo => m_Wrapper.m_Player_SkillTwo;
        public InputAction @Interaction => m_Wrapper.m_Player_Interaction;
        public InputAction @OpenBag => m_Wrapper.m_Player_OpenBag;
        public InputAction @Setting => m_Wrapper.m_Player_Setting;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @RightMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightMouse;
                @RightMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightMouse;
                @RightMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightMouse;
                @SkillOne.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillOne;
                @SkillOne.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillOne;
                @SkillOne.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillOne;
                @SkillTwo.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillTwo;
                @SkillTwo.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillTwo;
                @SkillTwo.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillTwo;
                @Interaction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteraction;
                @OpenBag.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenBag;
                @OpenBag.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenBag;
                @OpenBag.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenBag;
                @Setting.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSetting;
                @Setting.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSetting;
                @Setting.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSetting;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightMouse.started += instance.OnRightMouse;
                @RightMouse.performed += instance.OnRightMouse;
                @RightMouse.canceled += instance.OnRightMouse;
                @SkillOne.started += instance.OnSkillOne;
                @SkillOne.performed += instance.OnSkillOne;
                @SkillOne.canceled += instance.OnSkillOne;
                @SkillTwo.started += instance.OnSkillTwo;
                @SkillTwo.performed += instance.OnSkillTwo;
                @SkillTwo.canceled += instance.OnSkillTwo;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @OpenBag.started += instance.OnOpenBag;
                @OpenBag.performed += instance.OnOpenBag;
                @OpenBag.canceled += instance.OnOpenBag;
                @Setting.started += instance.OnSetting;
                @Setting.performed += instance.OnSetting;
                @Setting.canceled += instance.OnSetting;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnRightMouse(InputAction.CallbackContext context);
        void OnSkillOne(InputAction.CallbackContext context);
        void OnSkillTwo(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnOpenBag(InputAction.CallbackContext context);
        void OnSetting(InputAction.CallbackContext context);
    }
}
