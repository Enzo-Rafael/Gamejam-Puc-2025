using UnityEngine;
using UnityEngine.InputSystem;
public class PushNPull : MonoBehaviour
{
    [SerializeField] private Transform playerCamTranform;
    [SerializeField] private Transform objectGrabPoss;
    [SerializeField] private LayerMask pickUpLayerMask;
    public float pickUpDistance = 2f;
    private PlayerInputActions inputActions;

    private ItemGrabable objectGrabbable;

    void Start()
    {
        inputActions = new PlayerInputActions();

        inputActions.Player.Interaction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputActions.Player.Interaction.WasPressedThisFrame())
        {
            if (objectGrabbable == null)
            {
                if (Physics.Raycast(playerCamTranform.position, playerCamTranform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    Debug.Log("achou");
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPoss);
                        GetComponent<Move>().moveSpeed = 2.5f;
                    }

                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
                 GetComponent<Move>().moveSpeed = 5f;
            }
        }
    }
    
}
