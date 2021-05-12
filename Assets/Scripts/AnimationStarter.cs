using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class AnimationStarter : MonoBehaviour
{
    [SerializeField] private GameObject _externalModifier;

    private UnityEvent _runAway = new UnityEvent();
    private bool _isScared;

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

    void Update()
    {
        _speed = GetComponent<MovementByPoints>().Speed;
        
        _animator.SetFloat("Speed", _speed);

        Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).IsName("Walk/Run"));

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Walk/Run") && _isScared)
        {
            _runAway?.Invoke();
            _isScared = false;
        }
    }
    private void OnScared()
    {
        _animator.SetTrigger("Scared");
        
        _isScared = true;
        Debug.Log("Scared");
    }
}
