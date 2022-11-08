
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandableObstacle : Obstacle
{   
    Vector3 resizeSpeed = new Vector3 (3f,0,0);
    public GameObject cubeExpand;
    int resizeDirection = 1;

    // Update is called once per frame
    void Update()
    {
        cubeExpand.transform.localScale += (resizeSpeed*resizeDirection*Time.deltaTime);
        
        if (cubeExpand.transform.localScale.x >= 3f)
        {
            resizeDirection = -1;
        }
        if (cubeExpand.transform.localScale.x <= 1f)
        {
            resizeDirection = 1;
        }
    }
}
 
