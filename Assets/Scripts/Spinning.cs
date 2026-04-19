//amazing source https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/
using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField] private float _spinSpeed = 10f;
    [SerializeField] private bool _isClockwise = true;
    private float _currentAngle = 0f;

    void Update()
    {
        if(_isClockwise)
        {
            _currentAngle += _spinSpeed * Time.deltaTime;
        }
        else
        {
            _currentAngle -= _spinSpeed * Time.deltaTime;
        }

        Matrix3x3 rotation = Matrix3x3.RotationMatrix(_currentAngle);

        //For local rotation Right = X axis, Forward = Z axis, Up = Y axis
        Vector3 right = Matrix3x3.Multiply(rotation, Vector3.right);
        Vector3 forward = Matrix3x3.Multiply(rotation, Vector3.forward);
        Vector3 up = Matrix3x3.Multiply(rotation, Vector3.up);

        transform.rotation = Quaternion.LookRotation(up, right);
    }
}
