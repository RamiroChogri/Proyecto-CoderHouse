
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

    protected void Relocate(){
        transform.position = new Vector3(Random.Range(-9f,29f),transform.position.y,Random.Range(40f,400f));
    }
}
