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
        objectRigidbogy.useGravity = true;
        objectRigidbogy.constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationZ;
        
    }
    public void Drop()
    {
        this.objectGrabPointTranform = null;
        objectRigidbogy.useGravity = false;
        objectRigidbogy.constraints = RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezePositionZ;
        objectRigidbogy.constraints = RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationZ;
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
