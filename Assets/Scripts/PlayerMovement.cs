using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private LayerMask groundMask = ~0;
    [SerializeField] private float groundCheckDistance = 0.6f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform cameraTransform;

    private Rigidbody rb;
    private Vector2 moveInput;
    private bool jumpRequested;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.Get<float>() > 0.5f)
            jumpRequested = true;
    }

    void FixedUpdate()
    {
        Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);
        Vector3 desiredWorld;
        if (inputDir.sqrMagnitude > 0.001f)
        {
            if (cameraTransform != null)
            {
                Vector3 camForward = cameraTransform.forward;
                camForward.y = 0f;
                camForward.Normalize();

                Vector3 camRight = cameraTransform.right;
                camRight.y = 0f;
                camRight.Normalize();

                desiredWorld = (camRight * inputDir.x + camForward * inputDir.z) * moveSpeed;
            }
            else
            {
                desiredWorld = inputDir.normalized * moveSpeed;
            }
        }
        else
        {
            desiredWorld = Vector3.zero;
        }

        Vector3 vel = rb.linearVelocity;
        vel.x = desiredWorld.x;
        vel.z = desiredWorld.z;
        rb.linearVelocity = vel;

        Vector3 horizontalMove = new Vector3(desiredWorld.x, 0f, desiredWorld.z);
        if (horizontalMove.sqrMagnitude > 0.0001f)
        {
            Quaternion target = Quaternion.LookRotation(horizontalMove.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.fixedDeltaTime);
        }

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

        // jump
        if (jumpRequested && isGrounded)
        {
            float v = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            Vector3 v2 = rb.linearVelocity;
            v2.y = v;
            rb.linearVelocity = v2;
            SoundManager.PlaySound(SoundType.JUMP);
        }

        jumpRequested = false;
    }
}