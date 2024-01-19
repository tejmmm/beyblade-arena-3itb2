using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] private GameObject hrac;
    private Rigidbody hracRb;

    void Start()
    {
        hracRb = hrac.GetComponent<Rigidbody>();
        base.Start();
    }

    void Update()
    {
        moveSpeed = buffSpeed * (float)_vlastnosti.GetSpeed;
        rotationSpeed = maxRotationSpeed * _vlastnosti.GetPercentOfStaminaLeft;
        this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        this.rb.AddForce(Vector3.Normalize((hracRb.position + hracRb.GetAccumulatedForce() / 2) - this.rb.position) *
                         moveSpeed * Time.deltaTime); //Helikoptera funguje presne jak ma
    }
}