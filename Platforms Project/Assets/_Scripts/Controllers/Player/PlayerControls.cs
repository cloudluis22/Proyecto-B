// GENERATED AUTOMATICALLY FROM 'Assets/_Scripts/Controllers/Player/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Land"",
            ""id"": ""2283e9f0-58bd-448b-aa07-758096177062"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ea997037-64ee-44f4-a4c7-133403e9ac89"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c66f3044-cb2c-42e6-83cb-4f50a702a923"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""9bfa0e94-1807-4c97-8c5c-76a74db5ef17"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""450b4819-3191-4df0-aa3a-e7b0250a1717"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""517a0e6b-b9c9-48d3-83c6-ef812efe8878"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Unpause"",
                    ""type"": ""Button"",
                    ""id"": ""45380d8d-04b3-4414-953b-faf7abf2f8c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""a4c17a23-cb53-4d78-9cd3-d31263e9278a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""5e8f0d74-f5ef-4667-b993-058dc0d7a4c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug HP"",
                    ""type"": ""Button"",
                    ""id"": ""46a85771-623b-4e83-90a1-fc21be00c076"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SprintStart"",
                    ""type"": ""Button"",
                    ""id"": ""e9f90d97-161a-42bc-9eee-5cb0992564a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SprintEnd"",
                    ""type"": ""Button"",
                    ""id"": ""3ac1e0c9-641e-4bc8-8160-484d422fc50d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""ca6b77c9-c333-443a-98be-22e65ab2dc66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PickUp"",
                    ""type"": ""Button"",
                    ""id"": ""b69fb3e7-ac2a-4c65-bd3c-3bd17581e79c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""GetWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""037dc8f5-934d-4d1a-b80b-566b07d9c8c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dea07140-b5ed-46b2-8e1b-e547c674c0c9"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""799e52c6-9d4b-4b53-afa1-29ebe5b79990"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""32a2efc8-bd8c-47c6-8a2e-8620516e3bef"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""97793098-4003-4f57-9e8a-a0678cc244e5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""426411dc-3326-4622-a8b5-0b08be557a96"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""857b9f58-d653-4c6f-878c-c6120191480a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""72b2a77c-2a3d-4a15-9972-04456529c1c9"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e9d5668-3425-415e-a6e3-b70ea11657d9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5662f6e9-b3fa-4129-8b6d-8f0c78e79613"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""926fbb9b-5bbf-4e16-8578-f46572e459c6"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""053732ba-42b8-481c-af13-df01c1c96ced"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d86c0174-88cf-420e-92b5-1a333750ad9b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ee53b9e-08ce-4a4d-86e0-b2bcb75b31a5"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cafa5d1-2943-4a5f-985e-d12b19d8e626"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18a3ecd7-b1b9-45c8-8921-db0eb1a6a266"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b7e92cb-7ed1-4520-8a65-7e8ca3e637a9"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b6e89e9-5677-4b40-ac2a-bb09b8a0d764"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19af25de-cea2-4346-a505-db9bd793c02a"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ca7e220-2f95-4e31-a9ff-9a4bbd87bb31"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7f224e2-3f34-455a-b6ec-cd61efa2602b"",
                    ""path"": ""<DualShockGamepad>/touchpadButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff93d75f-76a6-45c6-99f9-33bcd24c9e7f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cad2fbfd-6038-403a-a04d-849992a52133"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug HP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""128bd337-3d81-407e-81a6-79c541cdb50b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bdf8171-8790-4a4e-8a72-e879c68f496a"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49b84398-929a-4153-aa96-7998d621816c"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20c04830-3db1-4f06-838d-3b6b4f54e65b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8938984c-b089-4b12-96af-68e9fb52c912"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""af311cdb-9805-4280-a52e-3c97f818db75"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""f60dfda1-d91d-4c30-be13-144020c9fca4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""551e04c5-f492-43ec-81de-3e826fac5fb6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""af632cc6-9214-4801-8154-87390dd0b6c3"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""ada952e5-fef3-4041-8c70-e96950b923e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""927e4007-0fe1-426d-9c65-8c5613fbe08c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Land
        m_Land = asset.FindActionMap("Land", throwIfNotFound: true);
        m_Land_Move = m_Land.FindAction("Move", throwIfNotFound: true);
        m_Land_Jump = m_Land.FindAction("Jump", throwIfNotFound: true);
        m_Land_Look = m_Land.FindAction("Look", throwIfNotFound: true);
        m_Land_Attack = m_Land.FindAction("Attack", throwIfNotFound: true);
        m_Land_Pause = m_Land.FindAction("Pause", throwIfNotFound: true);
        m_Land_Unpause = m_Land.FindAction("Unpause", throwIfNotFound: true);
        m_Land_Quit = m_Land.FindAction("Quit", throwIfNotFound: true);
        m_Land_Restart = m_Land.FindAction("Restart", throwIfNotFound: true);
        m_Land_DebugHP = m_Land.FindAction("Debug HP", throwIfNotFound: true);
        m_Land_SprintStart = m_Land.FindAction("SprintStart", throwIfNotFound: true);
        m_Land_SprintEnd = m_Land.FindAction("SprintEnd", throwIfNotFound: true);
        m_Land_Crouch = m_Land.FindAction("Crouch", throwIfNotFound: true);
        m_Land_PickUp = m_Land.FindAction("PickUp", throwIfNotFound: true);
        m_Land_GetWeapon = m_Land.FindAction("GetWeapon", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Newaction = m_UI.FindAction("New action", throwIfNotFound: true);
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_Attack = m_Combat.FindAction("Attack", throwIfNotFound: true);
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

    // Land
    private readonly InputActionMap m_Land;
    private ILandActions m_LandActionsCallbackInterface;
    private readonly InputAction m_Land_Move;
    private readonly InputAction m_Land_Jump;
    private readonly InputAction m_Land_Look;
    private readonly InputAction m_Land_Attack;
    private readonly InputAction m_Land_Pause;
    private readonly InputAction m_Land_Unpause;
    private readonly InputAction m_Land_Quit;
    private readonly InputAction m_Land_Restart;
    private readonly InputAction m_Land_DebugHP;
    private readonly InputAction m_Land_SprintStart;
    private readonly InputAction m_Land_SprintEnd;
    private readonly InputAction m_Land_Crouch;
    private readonly InputAction m_Land_PickUp;
    private readonly InputAction m_Land_GetWeapon;
    public struct LandActions
    {
        private @PlayerControls m_Wrapper;
        public LandActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Land_Move;
        public InputAction @Jump => m_Wrapper.m_Land_Jump;
        public InputAction @Look => m_Wrapper.m_Land_Look;
        public InputAction @Attack => m_Wrapper.m_Land_Attack;
        public InputAction @Pause => m_Wrapper.m_Land_Pause;
        public InputAction @Unpause => m_Wrapper.m_Land_Unpause;
        public InputAction @Quit => m_Wrapper.m_Land_Quit;
        public InputAction @Restart => m_Wrapper.m_Land_Restart;
        public InputAction @DebugHP => m_Wrapper.m_Land_DebugHP;
        public InputAction @SprintStart => m_Wrapper.m_Land_SprintStart;
        public InputAction @SprintEnd => m_Wrapper.m_Land_SprintEnd;
        public InputAction @Crouch => m_Wrapper.m_Land_Crouch;
        public InputAction @PickUp => m_Wrapper.m_Land_PickUp;
        public InputAction @GetWeapon => m_Wrapper.m_Land_GetWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Land; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandActions set) { return set.Get(); }
        public void SetCallbacks(ILandActions instance)
        {
            if (m_Wrapper.m_LandActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_LandActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnLook;
                @Attack.started -= m_Wrapper.m_LandActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnAttack;
                @Pause.started -= m_Wrapper.m_LandActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnPause;
                @Unpause.started -= m_Wrapper.m_LandActionsCallbackInterface.OnUnpause;
                @Unpause.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnUnpause;
                @Unpause.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnUnpause;
                @Quit.started -= m_Wrapper.m_LandActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnQuit;
                @Restart.started -= m_Wrapper.m_LandActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnRestart;
                @DebugHP.started -= m_Wrapper.m_LandActionsCallbackInterface.OnDebugHP;
                @DebugHP.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnDebugHP;
                @DebugHP.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnDebugHP;
                @SprintStart.started -= m_Wrapper.m_LandActionsCallbackInterface.OnSprintStart;
                @SprintStart.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnSprintStart;
                @SprintStart.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnSprintStart;
                @SprintEnd.started -= m_Wrapper.m_LandActionsCallbackInterface.OnSprintEnd;
                @SprintEnd.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnSprintEnd;
                @SprintEnd.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnSprintEnd;
                @Crouch.started -= m_Wrapper.m_LandActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnCrouch;
                @PickUp.started -= m_Wrapper.m_LandActionsCallbackInterface.OnPickUp;
                @PickUp.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnPickUp;
                @PickUp.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnPickUp;
                @GetWeapon.started -= m_Wrapper.m_LandActionsCallbackInterface.OnGetWeapon;
                @GetWeapon.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnGetWeapon;
                @GetWeapon.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnGetWeapon;
            }
            m_Wrapper.m_LandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Unpause.started += instance.OnUnpause;
                @Unpause.performed += instance.OnUnpause;
                @Unpause.canceled += instance.OnUnpause;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @DebugHP.started += instance.OnDebugHP;
                @DebugHP.performed += instance.OnDebugHP;
                @DebugHP.canceled += instance.OnDebugHP;
                @SprintStart.started += instance.OnSprintStart;
                @SprintStart.performed += instance.OnSprintStart;
                @SprintStart.canceled += instance.OnSprintStart;
                @SprintEnd.started += instance.OnSprintEnd;
                @SprintEnd.performed += instance.OnSprintEnd;
                @SprintEnd.canceled += instance.OnSprintEnd;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @PickUp.started += instance.OnPickUp;
                @PickUp.performed += instance.OnPickUp;
                @PickUp.canceled += instance.OnPickUp;
                @GetWeapon.started += instance.OnGetWeapon;
                @GetWeapon.performed += instance.OnGetWeapon;
                @GetWeapon.canceled += instance.OnGetWeapon;
            }
        }
    }
    public LandActions @Land => new LandActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_Attack;
    public struct CombatActions
    {
        private @PlayerControls m_Wrapper;
        public CombatActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Combat_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface ILandActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnUnpause(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnDebugHP(InputAction.CallbackContext context);
        void OnSprintStart(InputAction.CallbackContext context);
        void OnSprintEnd(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnGetWeapon(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface ICombatActions
    {
        void OnAttack(InputAction.CallbackContext context);
    }
}
