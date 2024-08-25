using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private Health _health;

    private void Awake()
    {
        Respawn();
    }

    private void OnEnable()
    {
        _health.Damaged += OnDamaged;
    }

    private void Update()
    {
        Vector3 direction = _playerTarget.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnDamaged(int health)
    {
        if (health <= 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = new Vector3(Random.Range(-10f, 10f), transform.position.y, Random.Range(-10f, 10f));
    }
}