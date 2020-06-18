using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
   [SerializeField] private Transform target;
   [SerializeField] private float smoothness = 1f;
   [SerializeField] private Vector3 offset;
   private bool _isTargetNull;

   // Start is called before the first frame update
    void Start()
    {
        _isTargetNull = target == null;
    }

    private void LateUpdate()
    {
        if (_isTargetNull)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, b: target.position + offset, Time.deltaTime * smoothness);
    }
}
