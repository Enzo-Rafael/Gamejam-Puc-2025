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
        
    }

    void Update()
    {
        

        Vector3 moveDir = new Vector3(inputMove.x,0,inputMove.y);
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

    
}
