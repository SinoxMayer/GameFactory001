using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float patrolRange;
    [SerializeField] private float moveSpeed;

    private Vector3 initialPosition;
    private Vector3 minPosition;
    private Vector3 maxPosition;
    private Vector3 destinationPoint;


    private void Awake()
    {
        initialPosition = transform.position;
        
        //bu alanlarda maximum ve minimum posisyonları veriyoruz ve patrol range kadar gezdiyoruz.
        minPosition = initialPosition + Vector3.left * patrolRange;
        maxPosition = initialPosition + Vector3.right * patrolRange;

        SetDestination(maxPosition);
    }

    private void SetDestination(Vector3 destination)
    {
        destinationPoint = destination;
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, maxPosition) < 0.1f)
        {
            SetDestination(minPosition);
        }
        else if (Vector3.Distance(transform.position, minPosition) < 0.1f)
        {
            SetDestination(maxPosition);
        }
        
        transform.position =
            Vector3.MoveTowards(transform.position,
                destinationPoint, 
                Time.deltaTime * moveSpeed);
    }
}
