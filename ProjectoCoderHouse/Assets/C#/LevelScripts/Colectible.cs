using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectible : Obstacle
{

    Animator animator;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
    }

    void Relocate(){
        transform.position = new Vector3(Random.Range(-9f,29f),0.5f,Random.Range(20f,150f));
    }

    void OnTriggerEnter(Collider colider)
    {
        if(colider.transform.gameObject.name == "Player"){
            animator.Play("Coin Collection", 0, 0.25f);
        }
    }

    //El set active desactiva el evento de obstacle, y nunca se reactiva,  

}
