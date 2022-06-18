using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private Slider _slider;

    private WaitForSeconds _delay = new WaitForSeconds(0.1f);
    private PlayerHealth _health;
    private float _targetValue;
    private float _step = 2f;
    private bool _isActive;

    private void Start()
    {
        _slider.value = _slider.maxValue;
        _targetValue = _slider.value;
        _player.TryGetComponent<PlayerHealth>(out _health);       
    }

    public void ChangeTargetValue()
    {
        _targetValue = _health.CurrentHealth;
        StartCoroutine(ChangeValue());
    }  
    private IEnumerator ChangeValue()
    {
        while (true)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _step);   
            
            if(_slider.value == _targetValue)
            {
                yield break;
            }
            else
            {
                yield return _delay;
            }
        }
    }
}
