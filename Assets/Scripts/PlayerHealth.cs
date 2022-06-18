using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UnityEvent _healthValueChanged;
    public float CurrentHealth { get; private set; }

    private float _maxHealth = 100f;

    public void TakeDamage(float damage)
    { 
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage,0,_maxHealth);
        _healthValueChanged?.Invoke();
    }

    public void TakeHeal(float heal)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + heal, 0, _maxHealth);
        _healthValueChanged?.Invoke();
    }

    private void Start() 
    {
        CurrentHealth = _maxHealth;
    }
}
