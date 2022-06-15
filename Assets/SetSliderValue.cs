
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetSliderValue : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _step = 2f;
    [SerializeField] private float _stepDelay = 0.1f;

    private float _targetValue;
    private float _healOrDamageValue = 10f;
    private WaitForSeconds _returnDelay;
        
    public void DoHeal()
    {
        _targetValue += _healOrDamageValue;   
    }
    public void DoDamage()
    {
        _targetValue -= _healOrDamageValue;
    }
    private void Start()
    {
        StartCoroutine(ChangeSliderValue());
        _targetValue = _healthBar.value;
        _returnDelay = new WaitForSeconds(_stepDelay);
    }
    private IEnumerator ChangeSliderValue()
    {
        while (true && _healthBar.value <= _healthBar.maxValue && _healthBar.value >= _healthBar.minValue)
        {   
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetValue,_step);
            yield return _returnDelay;
        }
    }
}
