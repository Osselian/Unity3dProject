using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    //[SerializeField] MeshRenderer _meshRenderer;

    [SerializeField] private GameObject _ghostsGroup;
    [SerializeField] private GameObject[] _ghosts;

    // Start is called before the first frame update
    void Start()
    {        
        //for (int i = 0; i < _ghostsGroup.childCount; i++)
        //{
        //    _ghosts[i] = _ghostsGroup.GetChild(i);
        //}
    }

    public void Enable()
    {
        for (int i = 0; i < _ghosts.Length; i++)
        {
            _ghosts[i].GetComponent<MeshRenderer>().enabled = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
