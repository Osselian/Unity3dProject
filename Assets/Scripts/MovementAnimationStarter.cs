using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationStarter : MonoBehaviour
{
    private Animator _animator;
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _speed = GetComponentInParent<MovementByPoints>().Speed;
        
        _animator.SetFloat("Speed", _speed);
    }
}
