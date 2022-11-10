using UnityEngine;
using UnityEngine.Events;

public class UIButtonController : MonoBehaviour
{
    [SerializeField]  private UnityEvent onPlayAgainButton;
     
    public void PlayAgain(){
        onPlayAgainButton.Invoke();
    }

    public void QuitGame(){
        Application.Quit();
    }


    
}
