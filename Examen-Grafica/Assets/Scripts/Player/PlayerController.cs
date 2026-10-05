using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    private PlayerInput inputReader;
    private IMovable movable;
    private IJumpable jumpable;
    private ILookable lookable;

    void Awake()
    {
        inputReader = GetComponent<PlayerInput>();
        movable = GetComponent<IMovable>();
        jumpable = GetComponent<IJumpable>();
        lookable = cameraTransform.GetComponent<ILookable>();
    }

    void OnEnable()
    {
        inputReader.JumpPressed += jumpable.Jump;
    }

    void OnDisable()
    {
        inputReader.JumpPressed -= jumpable.Jump;
    }

    void Update()
    {
        lookable.Look(inputReader.LookInput);

        Vector2 direction = CameraRelative(inputReader.MoveInput);
        movable.Move(direction);
    }

    private Vector2 CameraRelative(Vector2 input)
    {
        Vector3 forward = cameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 world = forward * input.y + right * input.x;
        return new Vector2(world.x, world.z);
    }
}