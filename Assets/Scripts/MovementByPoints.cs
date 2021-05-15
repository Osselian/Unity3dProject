using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementByPoints : MonoBehaviour
{
    [SerializeField] private Transform _pathIn;
    [SerializeField] private Transform _pathOut;
    [SerializeField] private float _speed;
    

    private UnityEvent _finalPointReached = new UnityEvent();

    public event UnityAction FinalPointReached
    {
        add => _finalPointReached.AddListener(value);
        remove => _finalPointReached.RemoveListener(value);
    }

    private Transform target;
    private Transform[] _points;
    private int _currrentPoint;

    public float Speed { get; private set; }

    public void OnEnable()
    {
        GetComponent<AnimationStarter>().RunAway += OnRunAway;
    }

    public void OnDisable()
    {
        GetComponent<AnimationStarter>().RunAway -= OnRunAway;
    }

    private void Start()
    {
        SetPath(_pathIn, 1);
    }

    private void Update()
    {
        if (_currrentPoint < _points.Length)
        {
            target = _points[_currrentPoint];

            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);

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

    private void SetPath(Transform path, float speed)
    {
        Speed = speed;
        _currrentPoint = 0;

        _points = new Transform[path.childCount];

        for (int i = 0; i < path.childCount; i++)
        {
            _points[i] = path.GetChild(i);
            Debug.Log(_points[i]);
        }
    }

    private void OnRunAway()
    {
        SetPath(_pathOut, 2f);
    }

    private void End()
    {
        Debug.Log("Final point reached");
        _speed = 0;
        _finalPointReached?.Invoke();
        
    }
}
