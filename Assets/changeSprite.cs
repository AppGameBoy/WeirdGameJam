using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] sprites;
    public Transform attackPoint;
    public int arrayPos=0;

    void Start()
    {
        sprites[0].gameObject.SetActive(false);
        sprites[1].gameObject.SetActive(true);

    }

    private void selectWeapon()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(sprites[arrayPos].ToString());
            if (arrayPos >=sprites.Length -1)
            {
                arrayPos = 0;
            }
            else
            {
                arrayPos += 1;
                sprites[arrayPos-1].gameObject.SetActive(false);

                sprites[arrayPos].gameObject.SetActive(true);
            }
        }
    }
}
