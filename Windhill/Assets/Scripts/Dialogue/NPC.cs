using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Dialogue defaultDialogue;
    [SerializeField] Dialogue eventDialogue;
    private Dialogue currentDialogue;
    bool canInteract;
    [SerializeField] string eventToListen;

    void Start()
    {
        currentDialogue = defaultDialogue;
        EventManager.Subscribe(eventToListen, OnEventTriggered);
    }

    void OnDestroy()
    {
        EventManager.Unsubscribe(eventToListen, OnEventTriggered);
    }

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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    public void Interact()
    {
        DialogueSystem.instance.StartDialogue(currentDialogue);
    }

    private void OnEventTriggered()
    {
        Debug.Log("aaaaaaa");
        currentDialogue = eventDialogue;
    }
}
