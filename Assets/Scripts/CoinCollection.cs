using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private Vector3 _scale = new Vector3(1.1f,1.1f,1.1f);

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Matrix3x3 scaleMatrix = Matrix3x3.ScaleMatrix(_scale.x, _scale.y, _scale.z);
            Vector3 currentScale = other.transform.localScale;
            Vector3 newScale = Matrix3x3.Multiply(scaleMatrix, currentScale);
            other.transform.localScale = new Vector3(newScale.x, newScale.y, newScale.z);
            Destroy(gameObject);
        }
    }
}
