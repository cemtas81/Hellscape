//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/MyController.inputactions
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

public partial class @MyController: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyController"",
    ""maps"": [
        {
            ""name"": ""MyGameplay"",
            ""id"": ""fbcae4a5-21ee-422c-a928-a4a03fb46dbe"",
            ""actions"": [
                {
                    ""name"": ""WeaponSelect"",
                    ""type"": ""Button"",
                    ""id"": ""0d7460d5-fc49-4ce2-8c65-859567610b68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""eb72586a-8ceb-450c-9c41-b54541fe9ae5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""6b60d976-f528-4e65-8c96-e1620cb3ddc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveCursor"",
                    ""type"": ""Value"",
                    ""id"": ""52966a46-1ea9-41d6-9dfb-eb1fe9250945"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""8f0b900c-2f99-423c-b5fa-3241b72cb140"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Geri"",
                    ""type"": ""Button"",
                    ""id"": ""bd3cc46c-baeb-4d69-b05d-ad77c42cd89a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""fee31847-e298-4cf5-9fc1-a0e136ee1f08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""b7cd0fdc-6ae6-44a5-b15f-8c9afd278337"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""7c677224-a0c2-4a2b-b084-f45cd9373433"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1ea45e5a-b1f8-4427-b8f0-fc2a1813f2c4"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44c133c0-a674-4599-a02b-f6034cf7fd64"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a72366e4-a3d9-4ed8-97f0-1d39e4bac786"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb2b5254-e274-4e61-a290-fe12e34a9b74"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e142fa2-df43-42ed-9b05-95f72a4240f2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c8219b3-819b-4c15-8421-5a2aaa1d31c9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b44ba90f-9299-4bf0-94c1-6f64b997572a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3aea8e71-1569-4b27-a2a1-3aa18ce50a41"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Geri"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a4cde22-becf-4254-9f9f-a3ff00b8973f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5ce6e64-244e-4344-aed7-ae145f133e3f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5236d95a-a3f7-494d-bea2-b133fcb9dab8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""26b64241-7d6e-42cb-a4fd-29932750e6c5"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4c4a787b-49e6-4e28-9f03-a02d770d98ef"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2a0721fe-b029-4868-a8e8-caec72395a48"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4f523aa1-8d58-4ac1-9350-ab4879fbc178"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0356daea-cee6-4fcb-9cad-9aa3b6b926d3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0d0cc17e-88af-410c-901f-37cfde276be0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9e9747f0-58a1-451a-9765-0253a3266b4c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""445ee342-05bb-492e-b0c9-bb5149560545"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4d83ac05-53a1-4223-8566-a9b8b86ca398"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keyboard"",
            ""bindingGroup"": ""keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MyGameplay
        m_MyGameplay = asset.FindActionMap("MyGameplay", throwIfNotFound: true);
        m_MyGameplay_WeaponSelect = m_MyGameplay.FindAction("WeaponSelect", throwIfNotFound: true);
        m_MyGameplay_Rotate = m_MyGameplay.FindAction("Rotate", throwIfNotFound: true);
        m_MyGameplay_Back = m_MyGameplay.FindAction("Back", throwIfNotFound: true);
        m_MyGameplay_MoveCursor = m_MyGameplay.FindAction("MoveCursor", throwIfNotFound: true);
        m_MyGameplay_Submit = m_MyGameplay.FindAction("Submit", throwIfNotFound: true);
        m_MyGameplay_Geri = m_MyGameplay.FindAction("Geri", throwIfNotFound: true);
        m_MyGameplay_Menu = m_MyGameplay.FindAction("Menu", throwIfNotFound: true);
        m_MyGameplay_MainMenu = m_MyGameplay.FindAction("MainMenu", throwIfNotFound: true);
        m_MyGameplay_SecondWeapon = m_MyGameplay.FindAction("SecondWeapon", throwIfNotFound: true);
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

    // MyGameplay
    private readonly InputActionMap m_MyGameplay;
    private List<IMyGameplayActions> m_MyGameplayActionsCallbackInterfaces = new List<IMyGameplayActions>();
    private readonly InputAction m_MyGameplay_WeaponSelect;
    private readonly InputAction m_MyGameplay_Rotate;
    private readonly InputAction m_MyGameplay_Back;
    private readonly InputAction m_MyGameplay_MoveCursor;
    private readonly InputAction m_MyGameplay_Submit;
    private readonly InputAction m_MyGameplay_Geri;
    private readonly InputAction m_MyGameplay_Menu;
    private readonly InputAction m_MyGameplay_MainMenu;
    private readonly InputAction m_MyGameplay_SecondWeapon;
    public struct MyGameplayActions
    {
        private @MyController m_Wrapper;
        public MyGameplayActions(@MyController wrapper) { m_Wrapper = wrapper; }
        public InputAction @WeaponSelect => m_Wrapper.m_MyGameplay_WeaponSelect;
        public InputAction @Rotate => m_Wrapper.m_MyGameplay_Rotate;
        public InputAction @Back => m_Wrapper.m_MyGameplay_Back;
        public InputAction @MoveCursor => m_Wrapper.m_MyGameplay_MoveCursor;
        public InputAction @Submit => m_Wrapper.m_MyGameplay_Submit;
        public InputAction @Geri => m_Wrapper.m_MyGameplay_Geri;
        public InputAction @Menu => m_Wrapper.m_MyGameplay_Menu;
        public InputAction @MainMenu => m_Wrapper.m_MyGameplay_MainMenu;
        public InputAction @SecondWeapon => m_Wrapper.m_MyGameplay_SecondWeapon;
        public InputActionMap Get() { return m_Wrapper.m_MyGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MyGameplayActions set) { return set.Get(); }
        public void AddCallbacks(IMyGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_MyGameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MyGameplayActionsCallbackInterfaces.Add(instance);
            @WeaponSelect.started += instance.OnWeaponSelect;
            @WeaponSelect.performed += instance.OnWeaponSelect;
            @WeaponSelect.canceled += instance.OnWeaponSelect;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Back.started += instance.OnBack;
            @Back.performed += instance.OnBack;
            @Back.canceled += instance.OnBack;
            @MoveCursor.started += instance.OnMoveCursor;
            @MoveCursor.performed += instance.OnMoveCursor;
            @MoveCursor.canceled += instance.OnMoveCursor;
            @Submit.started += instance.OnSubmit;
            @Submit.performed += instance.OnSubmit;
            @Submit.canceled += instance.OnSubmit;
            @Geri.started += instance.OnGeri;
            @Geri.performed += instance.OnGeri;
            @Geri.canceled += instance.OnGeri;
            @Menu.started += instance.OnMenu;
            @Menu.performed += instance.OnMenu;
            @Menu.canceled += instance.OnMenu;
            @MainMenu.started += instance.OnMainMenu;
            @MainMenu.performed += instance.OnMainMenu;
            @MainMenu.canceled += instance.OnMainMenu;
            @SecondWeapon.started += instance.OnSecondWeapon;
            @SecondWeapon.performed += instance.OnSecondWeapon;
            @SecondWeapon.canceled += instance.OnSecondWeapon;
        }

        private void UnregisterCallbacks(IMyGameplayActions instance)
        {
            @WeaponSelect.started -= instance.OnWeaponSelect;
            @WeaponSelect.performed -= instance.OnWeaponSelect;
            @WeaponSelect.canceled -= instance.OnWeaponSelect;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Back.started -= instance.OnBack;
            @Back.performed -= instance.OnBack;
            @Back.canceled -= instance.OnBack;
            @MoveCursor.started -= instance.OnMoveCursor;
            @MoveCursor.performed -= instance.OnMoveCursor;
            @MoveCursor.canceled -= instance.OnMoveCursor;
            @Submit.started -= instance.OnSubmit;
            @Submit.performed -= instance.OnSubmit;
            @Submit.canceled -= instance.OnSubmit;
            @Geri.started -= instance.OnGeri;
            @Geri.performed -= instance.OnGeri;
            @Geri.canceled -= instance.OnGeri;
            @Menu.started -= instance.OnMenu;
            @Menu.performed -= instance.OnMenu;
            @Menu.canceled -= instance.OnMenu;
            @MainMenu.started -= instance.OnMainMenu;
            @MainMenu.performed -= instance.OnMainMenu;
            @MainMenu.canceled -= instance.OnMainMenu;
            @SecondWeapon.started -= instance.OnSecondWeapon;
            @SecondWeapon.performed -= instance.OnSecondWeapon;
            @SecondWeapon.canceled -= instance.OnSecondWeapon;
        }

        public void RemoveCallbacks(IMyGameplayActions instance)
        {
            if (m_Wrapper.m_MyGameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMyGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_MyGameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MyGameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MyGameplayActions @MyGameplay => new MyGameplayActions(this);
    private int m_keyboardSchemeIndex = -1;
    public InputControlScheme keyboardScheme
    {
        get
        {
            if (m_keyboardSchemeIndex == -1) m_keyboardSchemeIndex = asset.FindControlSchemeIndex("keyboard");
            return asset.controlSchemes[m_keyboardSchemeIndex];
        }
    }
    public interface IMyGameplayActions
    {
        void OnWeaponSelect(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnMoveCursor(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnGeri(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnMainMenu(InputAction.CallbackContext context);
        void OnSecondWeapon(InputAction.CallbackContext context);
    }
}
