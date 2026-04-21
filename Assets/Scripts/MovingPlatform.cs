using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    private Transform _target;
    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _target = _point1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlatform();
    }
    private void MovePlatform()
    {
        Vector3 direction = VectorMath3D.DirectionToTarget(transform.position, _target.position);
        direction = VectorMath3D.Normalize(direction);

        _rb.MovePosition(transform.position + direction * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, _target.position) < 0.1)
        {
            _target = _target == _point1 ? _point2 : _point1;
        }
    }
}
