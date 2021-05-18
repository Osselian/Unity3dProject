using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmVolumeAmplifier : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeIncreaseStrenght ;

    private AlarmTrigger _alarmTrigger;

    private void OnEnable()
    {
        _alarmTrigger = GetComponent<AlarmTrigger>();
        _audioSource.volume = 0;
        _alarmTrigger.Reached += OnReached;
    }

    private void OnDisable()
    {
        _alarmTrigger.Reached -= OnReached;
        StopCoroutine(AmplifyVolume());
        StopCoroutine(ReduceVolume());
    }
    
    private void OnReached()
    {
        StartCoroutine(AmplifyVolume());
    }

    private IEnumerator AmplifyVolume()
    {
        for (int i = 0; i < 255; i++)
        {
            _audioSource.volume += 1f / 255;
            yield return null;
        }
    }

    private IEnumerator ReduceVolume()
    {
        
        for (int i = 0; i < 255; i++)
        {
            _audioSource.volume -= 1f / 255;
            yield return null;
        }
    }
    private void Update()
    {
        if (_audioSource.volume == 1)
        {
            StopCoroutine(AmplifyVolume());
            StartCoroutine(ReduceVolume());
        }
        if (_audioSource.volume == 0)
        {
            StopCoroutine(ReduceVolume());
            StartCoroutine(AmplifyVolume());
        }
    }
}
