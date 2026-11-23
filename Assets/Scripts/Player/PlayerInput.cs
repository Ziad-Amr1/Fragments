using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerInput : MonoBehaviour
{
    public InputAction Move { get; private set; }
    public InputAction Jump { get; private set; }
    public InputAction Dash { get; private set; }

    public float MoveX => Move != null ? Move.ReadValue<float>() : 0f;
    public bool JumpPressed => Jump != null && Jump.WasPressedThisFrame();
    public bool JumpHeld => Jump != null && Jump.IsPressed();
    public bool DashPressed => Dash != null && Dash.WasPressedThisFrame();

    void Awake()
    {
        Move = new InputAction("Move", InputActionType.Value);
        Move.AddCompositeBinding("1DAxis")
            .With("Negative", "<Keyboard>/a")
            .With("Positive", "<Keyboard>/d");
        Move.AddCompositeBinding("1DAxis")
            .With("Negative", "<Keyboard>/leftArrow")
            .With("Positive", "<Keyboard>/rightArrow");
        Move.AddBinding("<Gamepad>/leftStick/x");
        Move.AddBinding("<Gamepad>/dpad/x");

        Jump = new InputAction("Jump", InputActionType.Button);
        Jump.AddBinding("<Keyboard>/space");
        Jump.AddBinding("<Gamepad>/buttonSouth");

        Dash = new InputAction("Dash", InputActionType.Button);
        Dash.AddBinding("<Keyboard>/leftShift");
        Dash.AddBinding("<Keyboard>/rightShift");
        Dash.AddBinding("<Gamepad>/buttonEast");
    }

    void OnEnable()
    {
        Move?.Enable();
        Jump?.Enable();
        Dash?.Enable();
    }

    void OnDisable()
    {
        Move?.Disable();
        Jump?.Disable();
        Dash?.Disable();
    }

    void OnDestroy()
    {
        Move?.Dispose();
        Jump?.Dispose();
        Dash?.Dispose();
    }
}
