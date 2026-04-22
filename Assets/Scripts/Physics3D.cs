using UnityEngine;

/// <summary>
/// A helper class for physics calculations. Students must implement the methods below.
/// Unity's built-in physics engine and Vector2/Vector3 math functions are not allowed,
/// except for Mathf functions.
/// </summary>
public static class Physics3D
{
    /// <summary>
    /// Calculates linear velocity given displacement and time.
    /// </summary>
    public static Vector3 CalculateVelocity(Vector3 displacement, float time)
    {
        Vector3 Velocity;
        Velocity.x = displacement.x/time;
        Velocity.y = displacement.y/time;
        Velocity.z = displacement.z/time;
        return Velocity; // TODO: Implement this
    }

    /// <summary>
    /// Calculates linear acceleration given initial and final velocity over time.
    /// </summary>
    public static Vector3 CalculateAcceleration(Vector3 initialVelocity, Vector3 finalVelocity, float time)
    {
        Vector3 DeltaVelocity;
        DeltaVelocity.x = finalVelocity.x - initialVelocity.x;
        DeltaVelocity.y = finalVelocity.y - initialVelocity.y;
        DeltaVelocity.z = finalVelocity.z - initialVelocity.z;
        Vector3 Acceleration;
        Acceleration.x = DeltaVelocity.x/time;
        Acceleration.y = DeltaVelocity.y/time;
        Acceleration.z = DeltaVelocity.z/time;
        return Acceleration; // TODO: Implement this
    }

    /// <summary>
    /// Calculates displacement given initial velocity, acceleration, and time.
    /// </summary>
    public static Vector3 CalculateDisplacement(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        Vector3 Displacement;
        Displacement.x = initialVelocity.x * time + (.5f) * acceleration.x * (time * time);
        Displacement.y = initialVelocity.y * time + (.5f) * acceleration.y * (time * time);
        Displacement.z = initialVelocity.z * time + (.5f) * acceleration.z * (time * time);
        return Displacement; // TODO: Implement this
    }

    /// <summary>
    /// Calculates angular velocity given angle and time.
    /// </summary>
    public static float CalculateAngularVelocity(float angle, float time)
    {
        //lower case omega is angular velocity
        float omega = angle/time;
        return omega; // TODO: Implement this
    }

    /// <summary>
    /// Calculates angular acceleration given initial and final angular velocity over time.
    /// </summary>
    public static float CalculateAngularAcceleration(float initialAV, float finalAV, float time)
    {
        //lower case alpha is angular acceleration
        float deltaAV = finalAV - initialAV;
        float alpha = deltaAV/time;
        return alpha; // TODO: Implement this
    }

    /// <summary>
    /// Calculates centripetal acceleration of a rotating body.
    /// </summary>
    public static float CalculateCentripetalAcceleration(float angularVelocity, float radius)
    {
        float cA = Mathf.Pow(angularVelocity, 2) * radius;
        return cA; // TODO: Implement this
    }

    /// <summary>
    /// Calculates net force on an object given mass and acceleration.
    /// </summary>
    public static Vector3 CalculateNetForce(float mass, Vector3 acceleration)
    {
        Vector3 force;
        force.x = mass * acceleration.x;
        force.y = mass * acceleration.y;
        force.z = mass * acceleration.z;
        return force; // TODO: Implement this
    }

    /// <summary>
    /// Calculates the resulting velocity of an object after an elastic collision.
    /// </summary>
    public static Vector3 CalculatePostCollisionVelocity(Vector3 velocity1, float mass1, Vector3 velocity2, float mass2)
    {
        Vector3 pcv1;
        pcv1.x = ((2 * mass2 * velocity2.x) + (velocity1.x * (mass2 - mass1)))/(mass1 + mass2);
        pcv1.y = ((2 * mass2 * velocity2.y) + (velocity1.y * (mass2 - mass1)))/(mass1 + mass2);
        pcv1.z = ((2 * mass2 * velocity2.z) + (velocity1.z * (mass2 - mass1)))/(mass1 + mass2);
        return pcv1; // TODO: Implement this
    }

    /// <summary>
    /// Returns gravitational acceleration vector (e.g., downward force).
    /// </summary>
    public static Vector3 CalculateGravity(float gravityMagnitude)
    {   
        Vector3 gravity;
        gravity.x = 0;
        gravity.y = 0 - gravityMagnitude;
        gravity.z = 0;
        return gravity; // TODO: Implement this
    }

    //added function for springs.
    public static Vector3 SpringForce(float springConstant, float displacement, Vector3 direction)
    {
        //F = -k*x
        Vector3 springForce;
        springForce = -springConstant * displacement * direction;
        return springForce;
    }
}