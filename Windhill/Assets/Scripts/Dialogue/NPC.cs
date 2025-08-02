using UnityEngine;

public class NPC : Interactable
{
    [SerializeField] Dialogue defaultDialogue;
    [SerializeField] Dialogue eventDialogue;
    private Dialogue currentDialogue;
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

    public override void Interact()
    {
        DialogueSystem.instance.StartDialogue(currentDialogue);
    }

    private void OnEventTriggered()
    {
        currentDialogue = eventDialogue;
    }
}
