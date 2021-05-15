using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationStarter : MonoBehaviour
{
    [SerializeField] private GameObject _externalModifier;

    private UnityEvent _runAway = new UnityEvent();

    public event UnityAction RunAway
    {
        add => _runAway.AddListener(value);
        remove => _runAway.RemoveListener(value);
    }

    private Animator _animator;
    private float _speed;


    public void OnEnable()
    {
        _externalModifier.GetComponent<GhostTrigger>().ScarySoundPlayed += OnScared;
    }

    //public void OnDisable()
    //{
    //    _externalModifier.GetComponent<GhostTrigger>().ScarySoundPlayed -= OnScared;
    //}

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _speed = GetComponent<MovementByPoints>().Speed;
        
        _animator.SetFloat("Speed", _speed);
    }
    private void OnScared()
    {
        _animator.SetTrigger("Scared");
        _runAway?.Invoke();
        Debug.Log("Scared");
    }
}
