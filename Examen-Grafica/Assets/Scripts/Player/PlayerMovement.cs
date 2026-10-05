using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour, IMovable, IJumpable
{
    public float speed = 6f;
    public float gravity = -20f;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private float verticalVelocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Move(Vector2 direction)
    {
        if (controller.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 movement = new Vector3(direction.x, 0f, direction.y) * speed;
        movement.y = verticalVelocity;

        controller.Move(movement * Time.deltaTime);
    }

    public void Jump()
    {
        if (controller.isGrounded)
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}