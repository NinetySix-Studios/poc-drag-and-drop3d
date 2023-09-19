using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    [SerializeField] private bool _triggerCondition = true;
    [SerializeField] private GameObject _sphere;
    [SerializeField] private Vector3 _offSet;


    private void Start()
    {
        Debug.Log("CubeObjectScript Initiated");
        _offSet = new Vector3(0, 1f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_triggerCondition)
        {
            if (other.TryGetComponent(out SnapScript _))
            {
                HitCube();
                _triggerCondition = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _triggerCondition = true;
    }

    private void HitCube()
    {
        Debug.Log("Goal!");
        _sphere.transform.position = transform.position + _offSet;
    }
}