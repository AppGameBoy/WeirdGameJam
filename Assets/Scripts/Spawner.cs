using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public float delay = 2f;
    public float speed = 3f;

    float nextTimeToSpawn;

    private void Start()
    {
        nextTimeToSpawn = Time.time;
    }

    private void Update()
    {
        if(Time.time > nextTimeToSpawn)
        {
            nextTimeToSpawn = Time.time + delay;
            GameObject go = Instantiate(itemToSpawn,transform.position,Quaternion.identity);
            go.AddComponent<Move>();
            go.GetComponent<Move>().speed = speed;
        }
    }

}

public class Move : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

   
}
