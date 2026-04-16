/*using System.IO.Compression;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

/*
considering that quarternions are usually not 2D, 
the formulae for all of these are simplified a lot
for the following because the x and y components will be 0.
*//*
public class Quaternion2D
{
    public float w, x, y, z;

    public Quaternion2D(float w, float x, float y, float z)
    {
        this.w = w;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static Quaternion2D FromEuler(float angleDegrees)
    {
        // Create a quaternion from a 2D Euler angle (degrees)
        float radians = angleDegrees * Mathf.Deg2Rad;
        
        float w = Mathf.Cos(radians/2);
        float x = 0;
        float y = 0;
        float z = Mathf.Sin(radians/2);
        return new Quaternion2D(w, x, y, z);
    }

    public float ToEuler()
    {
        // Convert this quaternion to a 2D Euler angle (degrees)
        float radians = 2 * Mathf.Atan2(z,w);
        float degrees = radians * Mathf.Rad2Deg;
        return degrees;
    }

    public static Quaternion2D FromMatrix(Matrix3x3 m)
    {
        // Create a quaternion from a 2x2 rotation matrix
        //find theta using sin and cos from 2x2 rotation matrix
        float a = m.values[0][0];
        float c = m.values[1][0];
        float theta = Mathf.Atan2(c, a);
        //creating quaternion
        float w = Mathf.Cos(theta/2);
        float x = 0;
        float y = 0;
        float z = Mathf.Sin(theta/2);
        return new Quaternion2D(w, x, y, z);
    }

    public Matrix3x3 ToMatrix()
    {
        // Convert this quaternion to a 2x2 rotation matrix
        float w = this.w;
        float z = this.z;

        float a = 1-2*Mathf.Pow(z, 2);
        float b = -2*w*z;
        float c = 2*w*z;
        float d = 1-2*Mathf.Pow(z, 2);
        return new Matrix3x3(a, b, c, d);
    }

    public Quaternion2D Conjugate()
    {
        // Return the conjugate of this quaternion
        return new Quaternion2D(w, x, y, -z);
    }

    public Vector2 Rotate(Vector2 v)
    {
        // Rotate a 2D vector using quaternion multiplication and conjugation
        
        //same as ToMatrix
        float w = this.w;
        float z = this.z;

        float a = 1-2*Mathf.Pow(z, 2);
        float b = -2*w*z;
        float c = 2*w*z;
        float d = 1-2*Mathf.Pow(z, 2);

        //rotate vector
        float xPrime = (a*v.x) + (b*v.y);
        float yPrime = (c*v.x) + (d*v.y);
        return new Vector2(xPrime, yPrime);
    }

    public Quaternion2D Multiply(Quaternion2D q)
    {
        // Multiply this quaternion with another
        float w1 = this.w;
        float z1 = this.z;

        float w2 = q.w;
        float z2 = q.z;

        float wPrime = w1*w2 - z1*z2;
        float xPrime = 0;
        float yPrime = 0;
        float zPrime = w1*z2 + z1*w2;
        return new Quaternion2D(wPrime, xPrime, yPrime, zPrime);
    }
}*/