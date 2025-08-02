using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] CinemachineCamera mainCamera;
    [SerializeField] CinemachineCamera[] virtualCameras;
    [SerializeField] string triggerTag;

    void Start()
    {
        SwitchCameras(mainCamera);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            CinemachineCamera targetCamera = other.GetComponentInChildren<CinemachineCamera>();
            SwitchCameras(targetCamera);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            SwitchCameras(mainCamera);
        }
    }

    void SwitchCameras(CinemachineCamera targetCamera)
    {
        foreach (CinemachineCamera camera in virtualCameras)
        {
            camera.enabled = camera == targetCamera;
        }
    }
}
