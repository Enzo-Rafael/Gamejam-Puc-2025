using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {
        DialogueSystem.instance.StartDialogue(dialogue);
    }
}
