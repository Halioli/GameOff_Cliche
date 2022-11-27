using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 12f;

    [SerializeField] float gravity = -9.81f;
    [SerializeField] Transform groundChecker;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [SerializeField] float jumpHeight = 3f;

    // Private
    private float x = 0f;
    private float z = 0f;
    private Vector3 move;

    private Vector3 velocity;
    private bool isGrounded;

    private bool canMove = true;
    private bool canJump = true;

    void Update()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Movement
        if (canMove)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            // Jump
            if (Input.GetButtonDown("Jump") && isGrounded && canJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void SetCanMove(bool _value) { canMove = _value; }
    public bool GetCanMove() { return canMove; }    
    public void SetCanJump(bool _value) { canJump = _value; }
    public bool GetCanJump() { return canJump; }
}
