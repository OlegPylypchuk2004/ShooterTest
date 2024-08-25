using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);
    }
}