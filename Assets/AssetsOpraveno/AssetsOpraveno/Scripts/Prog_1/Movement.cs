using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISetBuff
{
    public void SetBuff(float buff);
}
    

public class Movement : MonoBehaviour, ISetBuff
{
    [SerializeField]
    protected float maxRotationSpeed = 2000;
    protected float rotationSpeed;
    protected float moveSpeed;

    protected float buffSpeed = 1;

    protected Rigidbody rb;
    public Rigidbody Rb => rb;
    protected Vlastnosti _vlastnosti;

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        _vlastnosti = GetComponent<Vlastnosti>();
        moveSpeed = (float)_vlastnosti.GetSpeed;
        rotationSpeed = maxRotationSpeed;
    }

    public void SetBuff(float buffSpeed)
    {
        this.buffSpeed *= buffSpeed;
    }

    void Update()
    {
        moveSpeed = buffSpeed * (float)_vlastnosti.GetSpeed;
        rotationSpeed = maxRotationSpeed * _vlastnosti.GetPercentOfStaminaLeft;
        this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            rb.AddForce(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}