using UnityEngine;

public class BtnImputs : MonoBehaviour
{
    private PlayerInputActions inputActions;
    public GameObject canvasPause;
    void Start()
    {
        inputActions = new PlayerInputActions();
        canvasPause.SetActive(false);
        LockCursor();
        
        inputActions.Player.UI.Enable();  
    }
    void Update()
    {
        HandleCursor();
    }
    
    void HandleCursor()//Controle sobre a visibilidade do cursor
    {
        if (inputActions.Player.UI.WasPressedThisFrame() && Cursor.lockState != CursorLockMode.Locked)
        {
            LockCursor();
            canvasPause.SetActive(false);
        }
        else if(inputActions.Player.UI.WasPressedThisFrame())
        {
            UnlockCursor();
            canvasPause.SetActive(true);
        }
    }

    public void LockCursor()//Trava o Cursor
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()//Destrava o cursor
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
