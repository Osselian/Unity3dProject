using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlarmLoudController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeIncreaseStrenght ;

    private bool _isAlarmed;
    private bool _isRising;

    private void OnEnable()
    {
        _audioSource.volume = 0;
        GetComponent<AlarmTrigger>().Reached += OnReached;
    }

    private void OnDisable()
    {
        GetComponent<AlarmTrigger>().Reached -= OnReached;
    }
    
    private void OnReached()
    {
        _isAlarmed = true;
        _isRising = true;
    }
    private void Update()
    {
        if (_isAlarmed && _audioSource.volume == 0)
        {
            _isRising = true;
        }
        else if (_isAlarmed && _audioSource.volume == 1)
        {
            _isRising = false;
        }

        if (_isAlarmed && _isRising)
        {
            _audioSource.volume += _volumeIncreaseStrenght * Time.deltaTime;
        }        
        else if (_isAlarmed && _isRising == false)
        {
            _audioSource.volume -= _volumeIncreaseStrenght * Time.deltaTime;
        }
    }
}
