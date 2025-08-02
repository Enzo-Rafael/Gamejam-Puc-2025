using UnityEngine;

public class Void : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Respawn>().RepawnPlayer();
        }
    }
}
