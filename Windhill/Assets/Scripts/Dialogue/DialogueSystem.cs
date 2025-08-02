using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;
    Dialogue currentDialogue;
    int dialogueIndex;

    [Header("UI Elements")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text speakerName;
    [SerializeField] TMP_Text dialogueText;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        dialogueIndex = 0;
        speakerName.text = currentDialogue.speakerName;
        dialogueText.text = currentDialogue.texts[0];
        dialoguePanel.SetActive(true);
    }

    public void NextLine()
    {
        if (dialogueIndex < currentDialogue.texts.Length - 1)
        {
            dialogueIndex++;
            dialogueText.text = currentDialogue.texts[0];
        }
        else
        {
            Debug.Log("Cabo o papo");
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        currentDialogue = null;
    }
}
