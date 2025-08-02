using UnityEngine;

public class InteractionPoint : Interactable
{
    [SerializeField] GameObject prefab;

    [SerializeField] string eventToTrigger;

    public override void Interact()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        GetComponent<BoxCollider>().enabled = false;
        interactionIcon.SetActive(false);
        EventManager.TriggerEvent(eventToTrigger);
    }
}
