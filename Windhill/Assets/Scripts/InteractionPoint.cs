using UnityEngine;

public class InteractionPoint : Interactable
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform spawn;
    [SerializeField] Light[] lightsToToggle;

    [SerializeField] string eventToTrigger;

    public override void Interact()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        GetComponent<BoxCollider>().enabled = false;
        GameObject.Find("Player").GetComponent<Respawn>().lastSpawnPoint = spawn;
        interactionIcon.SetActive(false);
        EventManager.TriggerEvent(eventToTrigger);
        foreach(Light l in lightsToToggle)
        {
            l.enabled = true;
        }
    }
}
