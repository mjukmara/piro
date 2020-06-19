// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""CameraRig"",
            ""id"": ""1df74be9-59a1-4d1d-a98e-659a697491c0"",
            ""actions"": [
                {
                    ""name"": ""Pan"",
                    ""type"": ""PassThrough"",
                    ""id"": ""28f27596-90ac-45a5-a211-40b574a4fb84"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3362e32f-a86b-43e1-b4f4-ab4384d85985"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e1ab2e40-e8c6-4d73-ad5d-c5cd9ff48149"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DragIndicator"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4b34c689-583f-4c75-9f6d-b231b2785e89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateIndicator"",
                    ""type"": ""PassThrough"",
                    ""id"": ""25bd9638-657f-4c32-960b-ba75d0e54bfa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9433a2f3-2612-4b00-98d0-624484e454ff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""119ba549-9c9c-469f-924f-b0172d969c29"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""11853a3f-4a0f-464e-8187-046b30defe47"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8df40b6e-b384-483f-8e12-04d16d52a641"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cc1257de-fb1b-4a61-adf4-4b1482403a10"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1f52ad0a-15c1-4581-9693-4d51abb06e84"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-16,max=16)"",
                    ""groups"": ""Mouse"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcee2823-0d26-440c-9847-76ea2f09876b"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c76f5250-93e4-46c8-b069-7e2c92eb6f7d"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""DragIndicator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e012679f-9c3a-43cd-b3ad-d9ab4f18ea1c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""RotateIndicator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TileBuilder"",
            ""id"": ""31f89fd9-146b-4df6-9acf-8434dcb45796"",
            ""actions"": [
                {
                    ""name"": ""Draw"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1a4e0cf9-c151-4380-8cab-6d3a3e68caff"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClearBrush"",
                    ""type"": ""Button"",
                    ""id"": ""1b948911-6d06-41b3-8f62-00735bc067a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a43650c9-fe90-4dec-a244-59d973013ded"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Draw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6898d23-000f-4b93-a2bb-6da6a85f702e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ClearBrush"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d96fd309-afd6-4a5f-ba40-98e569311207"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""ClearBrush"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CameraRig
        m_CameraRig = asset.FindActionMap("CameraRig", throwIfNotFound: true);
        m_CameraRig_Pan = m_CameraRig.FindAction("Pan", throwIfNotFound: true);
        m_CameraRig_Zoom = m_CameraRig.FindAction("Zoom", throwIfNotFound: true);
        m_CameraRig_Rotate = m_CameraRig.FindAction("Rotate", throwIfNotFound: true);
        m_CameraRig_DragIndicator = m_CameraRig.FindAction("DragIndicator", throwIfNotFound: true);
        m_CameraRig_RotateIndicator = m_CameraRig.FindAction("RotateIndicator", throwIfNotFound: true);
        // TileBuilder
        m_TileBuilder = asset.FindActionMap("TileBuilder", throwIfNotFound: true);
        m_TileBuilder_Draw = m_TileBuilder.FindAction("Draw", throwIfNotFound: true);
        m_TileBuilder_ClearBrush = m_TileBuilder.FindAction("ClearBrush", throwIfNotFound: true);
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

    // CameraRig
    private readonly InputActionMap m_CameraRig;
    private ICameraRigActions m_CameraRigActionsCallbackInterface;
    private readonly InputAction m_CameraRig_Pan;
    private readonly InputAction m_CameraRig_Zoom;
    private readonly InputAction m_CameraRig_Rotate;
    private readonly InputAction m_CameraRig_DragIndicator;
    private readonly InputAction m_CameraRig_RotateIndicator;
    public struct CameraRigActions
    {
        private @InputMaster m_Wrapper;
        public CameraRigActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pan => m_Wrapper.m_CameraRig_Pan;
        public InputAction @Zoom => m_Wrapper.m_CameraRig_Zoom;
        public InputAction @Rotate => m_Wrapper.m_CameraRig_Rotate;
        public InputAction @DragIndicator => m_Wrapper.m_CameraRig_DragIndicator;
        public InputAction @RotateIndicator => m_Wrapper.m_CameraRig_RotateIndicator;
        public InputActionMap Get() { return m_Wrapper.m_CameraRig; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraRigActions set) { return set.Get(); }
        public void SetCallbacks(ICameraRigActions instance)
        {
            if (m_Wrapper.m_CameraRigActionsCallbackInterface != null)
            {
                @Pan.started -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnPan;
                @Pan.performed -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnPan;
                @Pan.canceled -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnPan;
                @Zoom.started -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnZoom;
                @Rotate.started -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnRotate;
                @DragIndicator.started -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnDragIndicator;
                @DragIndicator.performed -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnDragIndicator;
                @DragIndicator.canceled -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnDragIndicator;
                @RotateIndicator.started -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnRotateIndicator;
                @RotateIndicator.performed -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnRotateIndicator;
                @RotateIndicator.canceled -= m_Wrapper.m_CameraRigActionsCallbackInterface.OnRotateIndicator;
            }
            m_Wrapper.m_CameraRigActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pan.started += instance.OnPan;
                @Pan.performed += instance.OnPan;
                @Pan.canceled += instance.OnPan;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @DragIndicator.started += instance.OnDragIndicator;
                @DragIndicator.performed += instance.OnDragIndicator;
                @DragIndicator.canceled += instance.OnDragIndicator;
                @RotateIndicator.started += instance.OnRotateIndicator;
                @RotateIndicator.performed += instance.OnRotateIndicator;
                @RotateIndicator.canceled += instance.OnRotateIndicator;
            }
        }
    }
    public CameraRigActions @CameraRig => new CameraRigActions(this);

    // TileBuilder
    private readonly InputActionMap m_TileBuilder;
    private ITileBuilderActions m_TileBuilderActionsCallbackInterface;
    private readonly InputAction m_TileBuilder_Draw;
    private readonly InputAction m_TileBuilder_ClearBrush;
    public struct TileBuilderActions
    {
        private @InputMaster m_Wrapper;
        public TileBuilderActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Draw => m_Wrapper.m_TileBuilder_Draw;
        public InputAction @ClearBrush => m_Wrapper.m_TileBuilder_ClearBrush;
        public InputActionMap Get() { return m_Wrapper.m_TileBuilder; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TileBuilderActions set) { return set.Get(); }
        public void SetCallbacks(ITileBuilderActions instance)
        {
            if (m_Wrapper.m_TileBuilderActionsCallbackInterface != null)
            {
                @Draw.started -= m_Wrapper.m_TileBuilderActionsCallbackInterface.OnDraw;
                @Draw.performed -= m_Wrapper.m_TileBuilderActionsCallbackInterface.OnDraw;
                @Draw.canceled -= m_Wrapper.m_TileBuilderActionsCallbackInterface.OnDraw;
                @ClearBrush.started -= m_Wrapper.m_TileBuilderActionsCallbackInterface.OnClearBrush;
                @ClearBrush.performed -= m_Wrapper.m_TileBuilderActionsCallbackInterface.OnClearBrush;
                @ClearBrush.canceled -= m_Wrapper.m_TileBuilderActionsCallbackInterface.OnClearBrush;
            }
            m_Wrapper.m_TileBuilderActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Draw.started += instance.OnDraw;
                @Draw.performed += instance.OnDraw;
                @Draw.canceled += instance.OnDraw;
                @ClearBrush.started += instance.OnClearBrush;
                @ClearBrush.performed += instance.OnClearBrush;
                @ClearBrush.canceled += instance.OnClearBrush;
            }
        }
    }
    public TileBuilderActions @TileBuilder => new TileBuilderActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface ICameraRigActions
    {
        void OnPan(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnDragIndicator(InputAction.CallbackContext context);
        void OnRotateIndicator(InputAction.CallbackContext context);
    }
    public interface ITileBuilderActions
    {
        void OnDraw(InputAction.CallbackContext context);
        void OnClearBrush(InputAction.CallbackContext context);
    }
}
