using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Player.GameOverEvent += LoadGameOverScreen;
    }

    void OnDisable()
    {
        Player.GameOverEvent -= LoadGameOverScreen;
    }
    // Update is called once per frame

    void LoadGameOverScreen(){
        Invoke("LoadScreen",2f);
    }

    void LoadScreen(){
        SceneManager.LoadScene(2);
    }
    public void LoadGame(){
        SceneManager.LoadScene(1);
    }
}
