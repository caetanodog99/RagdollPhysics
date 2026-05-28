using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMove : MonoBehaviour
{
    private Vector3 referencePosition;

    [SerializeField] private float speed = 100f;

    void Start()
    {
        referencePosition = new Vector3(-35f, 0.504f, transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, referencePosition, speed * Time.deltaTime);
    }
}
