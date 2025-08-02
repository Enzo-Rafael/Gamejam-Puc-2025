using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public string speakerName;
    public string[] texts;
    public Dialogue nextDialogue;
}
