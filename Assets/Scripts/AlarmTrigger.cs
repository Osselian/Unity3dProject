using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();

    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovementByPoints>(out MovementByPoints movementComponent));
        {
            _reached?.Invoke();
            GetComponent<AudioSource>().Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MovementByPoints>(out MovementByPoints movementComponent)) ;
        {
            _reached?.Invoke();
            GetComponent<AudioSource>().Stop();
        }
    }

}
