using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
public class Matrix3x3
{
    public List<List<float>> values;

    public Matrix3x3(
        float m00, float m01, float m02, 
        float m10, float m11, float m12,
        float m20, float m21, float m22
        )
    {
        values = new List<List<float>> {
            new List<float> { m00, m01, m02 },
            new List<float> { m10, m11, m12 },
            new List<float> { m20, m21, m22}
        };
    }

    public static Matrix3x3 Multiply(Matrix3x3 m1, Matrix3x3 m2)
    {
        // Multiply two 3x3 matrices and return the result
        //m1 position variables
        Matrix3x3 m3 = new Matrix3x3(0, 0, 0, 0, 0, 0, 0, 0, 0);

        for(int row = 0; row < 3; row++)
        {
            for(int col = 0; col < 3; col++)
            {
                float sum = 0f;
                for(int i = 0; i < 3; i++)
                {
                    sum += m1.values[row][i] * m2.values[i][col];
                }

                m3.values[row][col] = sum;
            }
        }
        return m3;
    }

    public static Vector3 Multiply(Matrix3x3 m, Vector3 v)
    {
        // Multiply matrix by vector and return transformed vector
        //Matrix variables
        float x =
        (m.values[0][0] * v.x) +
        (m.values[0][1] * v.y) +
        (m.values[0][2] * v.z);

        float y =
        (m.values[1][0] * v.x) +
        (m.values[1][1] * v.y) +
        (m.values[1][2] * v.z);

        float z =
        (m.values[2][0] * v.x) +
        (m.values[2][1] * v.y) +
        (m.values[2][2] * v.z);

        //Vector initialization and matrix vector multiplication
        Vector3 result = new Vector3(x, y, z);
        return result;
    }

    public float Determinant()
    {
        // Return the determinant of the matrix
        float a = values[0][0];
        float b = values[0][1];
        float c = values[0][2];

        float d = values[1][0];
        float e = values[1][1];
        float f = values[1][2];
        
        float g = values[2][0];
        float h = values[2][1];
        float i = values[2][2];

        float det =
            a * ((e * i) - (f * h)) -
            b * ((d * i) - (f * g)) +
            c * ((d * h) - (e * g));
        return det;
    }

    public Matrix3x3 Inverse()
    {
        // Return the inverse of the matrix if it exists

        float det = Determinant();

        //checking if there is an inverse
        if(det == 0)
        {
            return null;
        }
        
        float recipricalDet = 1/det;

        float a = values[0][0];
        float b = values[0][1];
        float c = values[0][2];

        float d = values[1][0];
        float e = values[1][1];
        float f = values[1][2];
        
        float g = values[2][0];
        float h = values[2][1];
        float i = values[2][2];
        //adjugate matrix is the transpose of the cofactor matrix
        Matrix3x3 adjugate = new Matrix3x3(
            ((e * i) - (f * h)), -((b * i) - (c * h)), +((b * f) - (c * e)),
            -((d * i) - (f * g)), +((a * i) - (c * g)), -((a * f) - (c * d)),
            +((d * h) - (e * g)), -((a * h) - (b * g)), +((a * e) - (b * d))
        );

        Matrix3x3 inverse = new Matrix3x3(0, 0, 0, 0, 0, 0, 0, 0, 0);

        for(int row = 0; row < 3; row++)
        {
            for(int col = 0; col < 3; col++)
            {
                inverse.values[row][col] = recipricalDet * adjugate.values[row][col];
            }
        }

        return inverse;
    }

    public static Matrix3x3 RotationMatrix(float angleDegrees)
    {
        // Return a rotation matrix for the given angle
        //We need radians and not degrees
        float radians = angleDegrees * Mathf.Deg2Rad;

        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);

        Matrix3x3 rotationMatrix = new Matrix3x3(
            cos, -sin, 0,
            sin, cos, 0,
            0, 0, 1
        );

        return rotationMatrix;
    }

    public static Matrix3x3 ScaleMatrix(float scaleX, float scaleY, float scaleZ)
    {
        // Return a scaling matrix
        Matrix3x3 scaleMatrix = new Matrix3x3(
            scaleX, 0, 0,
            0, scaleY, 0,
            0, 0, scaleZ
        );

        return scaleMatrix;
    }
}