using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Transform characterPreviewParent;
    [SerializeField] private float turnSpeed = 90f;
    // Update is called once per frame
    Vector3 currentRotation;
    Transform myTransform;
    
    
    void Start() {
        myTransform = GetComponent<Transform>();
        currentRotation = myTransform.eulerAngles;
    }
    void Update()
    {
        /*characterPreviewParent.RotateAround(characterPreviewParent.position, 
        characterPreviewParent.right, turnSpeed * Time.deltaTime);*/
        currentRotation.x += 20 * Time.deltaTime;
        myTransform.eulerAngles = currentRotation;
    }
}
