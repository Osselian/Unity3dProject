using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementByPoints : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    [SerializeField] private UnityEvent _finalPointReached = new UnityEvent();

    public event UnityAction Reached
    {
        add => _finalPointReached.AddListener(value);
        remove => _finalPointReached.RemoveListener(value);
    }

    private Transform target;
    public float Speed { get; private set; }

    private Transform[] _points;
    private int _currrentPoint;
        
    private void Start()
    {
        Speed = _speed;

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        if (_currrentPoint < _points.Length)
        {
            target = _points[_currrentPoint];

            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if (target.position == transform.position)
            {
                _currrentPoint++;
            }
        }
        else if (_currrentPoint == _points.Length)
        {
            End();
            _currrentPoint++;
        }
    }

    private void End()
    {
        _speed = 0;
        _finalPointReached?.Invoke();
        Debug.Log("Final point reached");
    }
}
