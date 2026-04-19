using Unity.VisualScripting;
using UnityEngine;

public static class VectorMath3D
{
    public static Vector3 Add(Vector3 a, Vector3 b)
    { return a + b; }

    public static Vector3 DirectionToTarget(Vector3 from, Vector3 to)
    {
        // TODO: Return vector pointing from 'from' to 'to'
        Vector3 direction = to - from;
        return direction;
    }

    public static Vector3 Normalize(Vector3 v)
    {
        // TODO: Return normalized vector
        float magnitude = Mathf.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z* v.z));
        
        if(magnitude == 0)
        {
            return Vector3.zero;
        }
        
        Vector3 normal = v/magnitude;
         return normal; 
    }

    public static float DotProduct(Vector3 a, Vector3 b)
    {
        // TODO: Return dot product
        float dot = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        return dot;
    }

    public static float AngleBetween(Vector3 a, Vector3 b)
    {
        // TODO: Return angle in degrees using arccos(dot / (|a||b|))
        float dot = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        float magA =  Mathf.Sqrt((a.x * a.x) + (a.y * a.y) + (a.z * a.z));
        float magB = Mathf.Sqrt((b.x * b.x) + (b.y * b.y) + (b.z * b.z));

        if(magA == 0 || magB == 0)
        {
            return 0f;
        }

        float angleRad = Mathf.Acos(dot/(magA * magB));
        float angleDeg = angleRad * Mathf.Rad2Deg;
        return angleDeg;
    }

    public static Vector3 CrossProduct(Vector3 a, Vector3 b)
    {
        // TODO: Return 3D cross product
        Vector3 cross = new Vector3(
            (a.y * b.z) - (a.z * b.y),
            (a.z * b.x) - (a.x * b.z),
            (a.x * b.y) - (a.y * b.x)
        );
        return cross;
    }

    public static float CalculateAngleRadians(float opposite, float adjacent)
    {
        // TODO: Return angle in radians using atan2
        float AngleRad = Mathf.Atan2(opposite, adjacent);
        return AngleRad;
    }

    public static float Pythagorean(float a, float b)
    {
        // TODO: Return sqrt(a� + b�)
        float c = Mathf.Sqrt((a * a) + (b * b));
        return c;
    }

    public static float Sin(float radians)
    {
        // TODO: Return sine of angle
        float SinAngle = Mathf.Sin(radians);
        return SinAngle;
    }

    public static float Cos(float radians)
    {
        // TODO: Return cosine of angle
        float CosAngle = Mathf.Cos(radians);
        return CosAngle;
    }

    public static bool IsInsideScanner(Vector2 dronePos, Vector2 scannerPos)
    {
        // Optional: Trigger zone logic
        return VectorMath3D.Pythagorean(dronePos.x - scannerPos.x, dronePos.y - scannerPos.y) < 2f;
    }
}