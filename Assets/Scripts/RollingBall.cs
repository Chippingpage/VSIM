using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    // Start is called before the first frame update


    // Mass of the object
    public float mass = 1.0f;

    // Initial velocity of the object
    public Vector3 initialVelocity = new Vector3(0.0f, 0.0f, 0.0f);

    // Update is called once per frame
    void Update()
    {
        // Calculate acceleration using Newton's second law
        Vector3 acceleration = CalculateAcceleration();

        // Update the velocity based on the acceleration
        initialVelocity += acceleration * Time.deltaTime;

        // Update the position based on the velocity
        transform.position += initialVelocity * Time.deltaTime;
    }

    Vector3 CalculateAcceleration()
    {
        // You might have some external forces affecting the object, like gravity
        Vector3 externalForces = Physics.gravity;

        // Calculate acceleration using Newton's second law
        Vector3 acceleration = externalForces / mass;

        return acceleration;
    }

}
