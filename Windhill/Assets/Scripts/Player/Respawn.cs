using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform lastSpawnPoint;

    /*void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colidiu");
        if(other.gameObject.CompareTag("Void")){

            transform.position = lastSpawnPoint.position;
        }
    }*/
    public void RepawnPlayer()
    {
        if(lastSpawnPoint == null){
            lastSpawnPoint = GameObject.FindWithTag("SpawnInicial").transform;
        }
        GetComponent<CharacterController>().enabled = false;
        transform.position = lastSpawnPoint.position;
        GetComponent<CharacterController>().enabled = true;
    }
}
