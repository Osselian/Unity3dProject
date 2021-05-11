using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLoudController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeIncreaseStrenght ;

    private bool IsAlarmed;

    private void OnEnable()
    {
        _audioSource.volume = 0;
        GetComponent<AlarmTrigger>().Reached += OnReached;
    }

    private void OnDisable()
    {
        GetComponent<AlarmTrigger>().Reached -= OnReached;
    }
    public void Play()
    {
        _audioSource.Play();
    }
    
    private void OnReached()
    {
        IsAlarmed = true;
    }
    private void Update()
    {
        if (IsAlarmed)
        {
            _audioSource.volume += _volumeIncreaseStrenght * Time.deltaTime;
        }
        
    }
}
