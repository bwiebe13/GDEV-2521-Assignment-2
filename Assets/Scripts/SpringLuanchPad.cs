using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
//test
public class SpringLuanchPad : MonoBehaviour
{
    [SerializeField] private float springConstant = 10f;
    [SerializeField] private float compression = 0.5f;
    private Vector3 direction = Vector3.down;
    void Awake()
    {
        //_rb = GetComponent<Rigidbo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }

        Rigidbody rb = other.attachedRigidbody;
        if(rb == null)
        {
            return;
        }


        Vector3 force = Physics3D.SpringForce(springConstant, compression, direction);
        rb.AddForce(force, ForceMode.Impulse);
    }
}
