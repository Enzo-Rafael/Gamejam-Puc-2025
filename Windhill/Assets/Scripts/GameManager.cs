using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject canvas_vitoria;
    public int cataventos = 0;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        canvas_vitoria.SetActive(false);
    }
    public void addCatavento()
    {
        cataventos += 1;
        if (cataventos >= 4)
        {
            UnlockCursor();
            GameObject.Find("Player").GetComponent<Move>().enabled = false;
            canvas_vitoria.SetActive(true);
        }
    }
    void UnlockCursor()//Destrava o cursor
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
