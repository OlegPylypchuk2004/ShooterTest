using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool _isCanAttack;

    private void Awake()
    {
        _isCanAttack = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        transform.localPosition = new Vector3(0f, -0.1f, 0f);

        yield return new WaitForSeconds(0.2f);

        _isCanAttack = true;
        transform.localPosition = new Vector3(0f, 0f, 0f);

        yield return new WaitForSeconds(1.5f);
    }
}