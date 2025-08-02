using UnityEngine;

public class InteractionPoint : MonoBehaviour
{
    bool canInteract;
    [SerializeField] GameObject interactionIcon;
    [SerializeField] GameObject prefab;

    [SerializeField] string eventToTrigger;

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            interactionIcon.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            interactionIcon.SetActive(false);
        }
    }

    void Interact()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        GetComponent<BoxCollider>().enabled = false;
        interactionIcon.SetActive(false);
        EventManager.TriggerEvent(eventToTrigger);
    }
}
