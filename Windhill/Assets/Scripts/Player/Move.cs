using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Move :  MonoBehaviour
{
//Movimentação basica dos jogadores
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 1.5f;
    public float gravity = -9.81f;
    public float rotationSmoothness  = 0.05f;

    [SerializeField] private Transform camRef;

    [Header("Components")]
    private CharacterController controller;
    private PlayerInputActions inputActions;
    [SerializeField] Animator anim;

    private Vector2 inputMove;

    private Vector3 velocity;
    private bool jumpQueued = false;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Start()
    {
        inputActions = new PlayerInputActions();

        inputActions.Player.Move.performed += ctx => inputMove = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += _ => inputMove = Vector2.zero;

        inputActions.Player.Jump.performed += _ => jumpQueued = true;

        inputActions.Player.Enable();
        LockCursor();
    }

    void Update()
    {
        HandleCursor();
        //camRef = FindObjectByType<CinemachineCamera>().tra
        Vector3 camForward = camRef.forward;
        Vector3 camRight = camRef.right;
        camForward.y = 0; 
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camRight * inputMove.x + camForward * inputMove.y;
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (jumpQueued && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            anim.SetTrigger("Jump");
        }

        jumpQueued = false;
        velocity.y += gravity * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            anim.SetBool("Walking", true);
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            // Aplica suavização usando Slerp
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness * Time.deltaTime);
            //transform.forward = moveDir;
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        controller.Move((moveDir * moveSpeed + velocity) * Time.deltaTime);
    }

    void HandleCursor()//Controle sobre a visibilidade do cursor
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            UnlockCursor();

        if (Mouse.current.rightButton.wasPressedThisFrame && Cursor.lockState != CursorLockMode.Locked)
            LockCursor();
    }

    void LockCursor()//Trava o Cursor
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()//Destrava o cursor
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
