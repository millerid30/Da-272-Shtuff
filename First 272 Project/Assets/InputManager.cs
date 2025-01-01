using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static Vector2 Movement;
    public static bool JumpWasPressed;
    public static bool JumpIsHeld;
    public static bool JumpWasReleased;
    public static bool RunIsHeld;

    public static bool FireIsHeld;
    public static bool FireIsReleased;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction runAction;
    private InputAction fireAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        moveAction = PlayerInput.actions["Move"];
        jumpAction = PlayerInput.actions["Jump"];
        runAction = PlayerInput.actions["Run"];
        fireAction = PlayerInput.actions["Fire"];

    }

    void Update()
    {
        Movement = moveAction.ReadValue<Vector2>();

        JumpWasPressed = jumpAction.WasPressedThisFrame();
        JumpIsHeld = jumpAction.IsPressed();
        JumpWasReleased = jumpAction.WasReleasedThisFrame();

        RunIsHeld = runAction.IsPressed();

        FireIsHeld = fireAction.IsPressed();
        FireIsReleased = fireAction.WasReleasedThisFrame();
    }
}