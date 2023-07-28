using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileGunTutorial : MonoBehaviour
{
    //bullet
    public GameObject bullet;
   

    //bullet force
    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammoCount;


    //bug fixing 
    public bool allowInvoke = true;


    private void Awake()
    {
        //make sure mag is full
        bulletsLeft = magSize;
        readyToShoot = true;
        
    }

    private void Update()
    {
        MyInput();

        //set ammo diplay 
        if (ammoCount != null)
            ammoCount.SetText(bulletsLeft / bulletsPerTap + " / " + magSize / bulletsPerTap);
    }

    private void MyInput()
    {
        //check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading) Reload();
        //automatic reload
        if (readyToShoot && shooting && !reloading && bulletsLeft <=0) Reload();    


        // Shooting
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bullet shots to zero
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        // find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        // check if ray hits somethihng
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //just a point a away from the player 

        //calcute direction from attackpoint to target 
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        // calcute spread
        float x = Random.Range(-spread,spread);
        float y = Random.Range(-spread, spread);

        //calculate new direction with spread 
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //just add spread to last 

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position,Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce , ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);


        // instantiate muzzle flash, if you have one 
        if(muzzleFlash != null)
            Instantiate(muzzleFlash,attackPoint.position, Quaternion.identity);


        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked )
        if (allowInvoke) 
        {
            Invoke("ResetShot" , timeBetweenShooting);
            allowInvoke = false;
        
        }

        // if more than one bulletpertap make sure to repeat shoot function 
        if(bulletsShot < bulletsPerTap && bulletsLeft > 0) {
            Invoke("Shoot", timeBetweenShots);
        
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

   private void ReloadFinished()
    {
        bulletsLeft = magSize;    
        reloading = false;
    }




}
