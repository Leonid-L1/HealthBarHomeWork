using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth { get; private set; }

    private float _maxHealth = 100f;
    private float _healOrDamageValue = 10;

    public void GetDamage()
    { 
        if(CurrentHealth > 0)
        CurrentHealth -= _healOrDamageValue;
    }

    public void GetHeal()
    {   
        if(CurrentHealth <_maxHealth)
        CurrentHealth += _healOrDamageValue;
    }

    private void Start() 
    {
        CurrentHealth = _maxHealth;
    }
}
