using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetValue : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _slider;

    private WaitForSeconds _returnDelay = new WaitForSeconds(0.1f);
    private PlayerHealth _currentPlayerHealth;
    private float _targetValue;
    private float _step = 2f;

    private void Start()
    {
        _slider.value = _slider.maxValue;
        _targetValue = _slider.value;
        _player.TryGetComponent<PlayerHealth>(out _currentPlayerHealth);
        StartCoroutine(ChangeValue());
    }
    public void ChangeTargetValue()
    {
        _targetValue = _currentPlayerHealth.CurrentHealth;
    }
    private IEnumerator ChangeValue()
    {
        while (true)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _step);
            yield return _returnDelay;
        }
    }
}
