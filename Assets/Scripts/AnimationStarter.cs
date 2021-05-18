using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationStarter : MonoBehaviour
{
    [SerializeField] private GameObject _externalModifier;

    private Animator _animator;
    private float _speed;

    public void OnEnable()
    {
        _externalModifier.GetComponent<GhostTrigger>().ScarySoundPlayed += OnScared;
    }

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _speed = GetComponent<MovementByPoints>().Speed;
        
        _animator.SetFloat("Speed", _speed);
    }
    private void OnScared()
    {
        _animator.SetTrigger("Scared");
    }
}
