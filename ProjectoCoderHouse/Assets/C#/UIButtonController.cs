using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAgain(){
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }


    
}
