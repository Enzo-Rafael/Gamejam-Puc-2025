using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject interactionIcon;
    public virtual void Interact() { }
    public virtual void OnEnter()
    {
        if (interactionIcon != null)
            interactionIcon.SetActive(true);
    }

    public virtual void OnExit()
    {
        if (interactionIcon != null)
            interactionIcon.SetActive(false);
    }
}
