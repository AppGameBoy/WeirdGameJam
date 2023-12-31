using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowingExample : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    public GameObject[] objectsToThrow;


    [Header("Settings")]
    //public int totalThrows;
    public float throwCooldown;
    //public TextMeshProUGUI ammoCount;

    [Header("Throwing")]
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }

        if (ammoCount != null)
            ammoCount.SetText("Food Left: "+totalThrows);
        */
        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToThrow)
        {
            Throw();
        }
    }

    private void Throw()
    {
        int n = Random.Range(0, objectsToThrow.Length);
        readyToThrow = false;

        Quaternion q = Quaternion.FromToRotation(Vector3.up, transform.forward);
        objectToThrow.transform.rotation = q * attackPoint.transform.rotation;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectsToThrow[n], attackPoint.position, q);
        //Debug.Log("cam rotation" + cam.rotation);
        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        
        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }
        

        forceDirection = cam.transform.forward;
        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        //totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
