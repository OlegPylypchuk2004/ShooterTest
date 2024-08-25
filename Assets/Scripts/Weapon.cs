using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _shootDelay;
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

        yield return new WaitForSeconds(_shootDelay);

        _isCanAttack = true;
    }
}