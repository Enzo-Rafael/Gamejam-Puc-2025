using UnityEngine;
using UnityEngine.UI;

public class InteractionIcon : MonoBehaviour
{
    [Header("Components UI")]
    [Tooltip("Componente de imagem para o marcador de waypoint.")]
    public Image img;

    [Tooltip("Transform do alvo que o waypoint aponta.")]
    public Transform target;

    [Tooltip("Deslocamento para a posição do marcador de waypoint.")]
    public Vector3 offset;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private void Start()
    {
        minX = img.GetPixelAdjustedRect().width / 2;
        maxX = Screen.width - minX;
        minY = img.GetPixelAdjustedRect().height / 2;
        maxY = Screen.height - minY;
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

            /*if (Vector3.Dot(target.position - transform.position, transform.forward) < 0)
            {
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);*/

            img.transform.position = pos;
        }
    }

    void OnEnable()
    {
        Debug.Log("Animação de aparecer");
    }

    void OnDisable()
    {
        Debug.Log("Animação de sumir");
    }
}