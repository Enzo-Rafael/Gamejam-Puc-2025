using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform lastSpawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Void")){
            transform.position = lastSpawnPoint.position;
        }
    }
}
