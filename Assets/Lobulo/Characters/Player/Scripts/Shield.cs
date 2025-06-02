using System;
using PrimeTween;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private TweenSettings<Vector3> _tweenSettings;
    [SerializeField] private float _shieldCoolDown;
    
    private Vector3 _startScale;
    
    private Tween _tween;
    
    private float _nextResetTime;
    private bool _isCoolingdown => Time.time < _nextResetTime;
    private void StartCoolDown() => _nextResetTime = Time.time + _shieldCoolDown;

    private void Awake()
    {
        _shield.SetActive(false);
        _startScale = _shield.transform.localScale;
    }

    public void UseShield()
    {
        _shield.SetActive(true);
        if(!_isCoolingdown) ChargeShield();
        
        _tween = Tween.Scale(_shield.transform, _shield.transform.localScale, Vector3.zero, _shieldCoolDown);
    }

    public void StopShield()
    {
        StartCoolDown();
        _tween.Stop();
        _shield.SetActive(false);
    }

    private void ChargeShield()
    {
        _shield.transform.localScale = _startScale;
    }
}
