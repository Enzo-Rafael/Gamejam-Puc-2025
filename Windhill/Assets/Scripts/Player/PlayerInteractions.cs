using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Interactable interactable;
    [SerializeField] Animator anim;

    void Start()
    {
        inputActions = new();
        inputActions.Player.Enable();
        inputActions.Player.Interaction_Dialogue.performed += _ => Interact();
    }

    void Interact()
    {
        if (interactable != null)
        {
            interactable.Interact();
            anim.SetTrigger("Interaction");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("Interaction"))
        {
            interactable = other.GetComponent<Interactable>();
            interactable.OnEnter();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("Interaction"))
        {
            if (interactable != null)
            {
                interactable.OnExit();
                interactable = null;
            }
        }
    }
}
