using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    private void Start()
    {
        transform.position = player.transform.position + offset;
    }
}
