using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;
    private Rigidbody rb;

    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (targetHit)
        {
            return;
        }
        else
        {
            targetHit = true;
        }
        //Debug.Log("sss");
        //check if you hit enemy 
        Debug.Log(collision.gameObject.GetComponent<Enemy>());
        if (collision.gameObject.GetComponent<Enemy>() !=null)
        {
            Debug.Log("HIT");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.TakeDamage(damage);
            Destroy(gameObject);
            GameManager.Instance.IncreaseScore(25);
            GameManager.Instance.scoreText 
        }

        if (collision.gameObject.CompareTag("floor") || collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }

        //make projectile stick to surface 
        rb.isKinematic = true;

        //make sure projectile moves with target

        transform.SetParent(collision.transform);
         
    }
}
