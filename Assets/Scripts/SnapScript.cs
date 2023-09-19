using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SnapScript : MonoBehaviour
{
    [SerializeField] private Vector3 _originalPosition;
    [SerializeField] private Vector3 _offSet;

    private void Start()
    {
        _originalPosition = transform.position;
        _offSet = new Vector3(0, 1f, 0);
        Debug.Log("SnapScript Initiated " + _originalPosition);
    }

    private void Update()
    {
            if (Input.GetMouseButtonUp(0))
            {
                transform.position = _originalPosition;
                Debug.Log("Original Position set! " + _originalPosition);
                Debug.Log("Current Position: " + _originalPosition);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubeObject _))
        {
            _originalPosition = other.transform.position + _offSet;
        }
    }
}