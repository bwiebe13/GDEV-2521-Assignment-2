using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
//test
public class SpringLuanchPad : MonoBehaviour
{
    [SerializeField] private float springConstant = 10f;
    [SerializeField] private float compression = 0.5f;
    private Vector3 direction = Vector3.down;

    private bool isOnSpring = false;

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

        isOnSpring = true;
        Vector3 force = Physics3D.SpringForce(springConstant, compression, direction);
        rb.AddForce(force, ForceMode.Impulse);
        other.GetComponent<PlayerController>().setLaunched();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isOnSpring = false;
        }
    }
}
