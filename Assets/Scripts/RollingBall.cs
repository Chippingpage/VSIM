using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    // Start is called before the first frame update


  
    public float mass = 1.0f;

  
    public Vector3 initialVelocity = new Vector3(0.0f, 0.0f, 0.0f);

 
    void Update()
    {
      
        Vector3 acceleration = CalculateAcceleration();

      
        initialVelocity += acceleration * Time.deltaTime;

        transform.position += initialVelocity * Time.deltaTime;
    }

    Vector3 CalculateAcceleration()
    {
        
        Vector3 externalForces = Physics.gravity;

       
        Vector3 acceleration = externalForces / mass;

        return acceleration;
    }

}
