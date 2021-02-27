using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elmasAlma : MonoBehaviour
{
    public GameObject kara;
    //public karakter kter;

    public void Start()
    {
       // kter = kara.GetComponent<karakter>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="karakter")
        {
            //kter.elmas += 1;
            Destroy(gameObject);
        }
    }
}
