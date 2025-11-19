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

    void FixedUpdate()
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

   
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
            Debug.Log("entrou");
        }
    }

    
    private void OnCollisionExit(Collision other)
    {
        Debug.Log("saiu");
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
