
using UnityEngine;

public class MobileObstacle : Obstacle
{

    Rigidbody m_Rigidbody;
    float m_Thrust = 15f;

    float HorizontalPositionMax = 29f;
    float HorizontalPositionMin = -9f;
    void Start(){
        m_Rigidbody = GetComponent<Rigidbody>();        
    }

    void FixedUpdate()
    {
        if(transform.position.x > HorizontalPositionMax){
            ChangeDirection(-1);
        }

        if(transform.position.x < HorizontalPositionMin){
            ChangeDirection(1);
        }
        Move();
    }

    void Move(){
        m_Rigidbody.velocity = new Vector3(m_Thrust, 0f, 0f);
    }

    void ChangeDirection(int direction){
        if(direction == -1){
            m_Thrust = -15f;
        }
        else
        {
            m_Thrust = 15f;
        }
    }

}
