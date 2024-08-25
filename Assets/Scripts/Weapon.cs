using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _shootDelay;
    [SerializeField] private int _damage;
    [SerializeField] private Animator _animator;
    [SerializeField] private CameraShaker _cameraShaker;

    private bool _isCanAttack;

    private void Awake()
    {
        _isCanAttack = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (_isCanAttack)
        {
            StartCoroutine(A());
        }
    }

    private IEnumerator A()
    {
        _isCanAttack = false;
        _animator.SetTrigger("Fire");

        _cameraShaker.Shake();

        PerformRaycast();

        yield return new WaitForSeconds(_shootDelay);

        _isCanAttack = true;
    }

    private void PerformRaycast()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Health health))
            {
                health.Damage(_damage);
            }
        }
    }
}