using UnityEngine;

public class BlockPlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player hit an obstacle: " + gameObject.name);
        }
    }
}