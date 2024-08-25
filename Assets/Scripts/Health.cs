using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _startHealth;

    private int _health;

    public event Action<int> Damaged;

    private void Awake()
    {
        _health = _startHealth;
    }

    public void Damage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            _health = 0;
        }

        Damaged?.Invoke(_health);
    }
}