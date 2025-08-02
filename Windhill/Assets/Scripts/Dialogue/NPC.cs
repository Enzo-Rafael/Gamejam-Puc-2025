using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Dialogue defaultDialogue;
    [SerializeField] Dialogue eventDialogue;
    private Dialogue currentDialogue;

    void Start()
    {
        currentDialogue = defaultDialogue;
        EventManager.Subscribe("EventName", OnEventTriggered);
    }

    void OnDestroy()
    {
        EventManager.Unsubscribe("EventName", OnEventTriggered);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {
        DialogueSystem.instance.StartDialogue(currentDialogue);
    }

    private void OnEventTriggered()
    {
        currentDialogue = eventDialogue;
    }
}
