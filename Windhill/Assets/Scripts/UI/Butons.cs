using UnityEngine;
using UnityEngine.SceneManagement;
public class Butons : MonoBehaviour
{
    public string scene;
    public void OnCloseGame()
    {
        Application.Quit();
    }
    
    public void OnButtonLoadScene(){
        SceneManager.LoadScene(scene);
    }
}
