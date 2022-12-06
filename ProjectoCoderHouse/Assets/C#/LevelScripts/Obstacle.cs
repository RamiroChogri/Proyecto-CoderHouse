
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Portal.LevelChangeEvent += Relocate;
    }

    void OnDisable()
    {
        Portal.LevelChangeEvent -= Relocate;
    }
    void Start() {
        Relocate();
    }

    void Relocate(){
        transform.position = new Vector3(Random.Range(-9f,29f),0.5f,Random.Range(40f,350f));
    }
}
