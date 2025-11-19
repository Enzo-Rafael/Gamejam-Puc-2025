using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Movimento horizontal
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (Vector3.Distance(startPos, transform.position) >= distance)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (Vector3.Distance(startPos, transform.position) >= distance)
                movingRight = true;
        }
    }

    // O player é "filho" da plataforma → acompanha o movimento
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
            Debug.Log("entrou");
        }
    }

    // Ao sair, deixa de ser filho
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
