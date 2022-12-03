using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectible : Obstacle
{
    // Start is called before the first frame update
    void Relocate(){
        transform.position = new Vector3(Random.Range(-9f,29f),0.5f,Random.Range(20f,150f));
        //this.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider colider)
    {
        if(colider.transform.gameObject.name == "Player"){
            //this.gameObject.SetActive(false);
        }
    }

    //El set active desactiva el evento de obstacle, y nunca se reactiva,  

}
