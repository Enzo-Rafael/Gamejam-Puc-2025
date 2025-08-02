using UnityEngine;

public class ItemGrabable : MonoBehaviour
{
    private Rigidbody objectRigidbogy;
    private Transform objectGrabPointTranform;
    public float lerpSpeed = 10f;
    private void Awake()
    {
        objectRigidbogy = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTranform)
    {
        this.objectGrabPointTranform = objectGrabPointTranform;
        objectRigidbogy.useGravity = false;
    }
    public void Drop()
    {
        this.objectGrabPointTranform = null;
        objectRigidbogy.useGravity = true;
    }
    private void FixedUpdate()
    {
        if (objectGrabPointTranform != null)
        {
            Vector3 newPoss = Vector3.Lerp(transform.position, objectGrabPointTranform.position, Time.deltaTime * lerpSpeed);
            objectRigidbogy.MovePosition(newPoss);

        }
    }
}
