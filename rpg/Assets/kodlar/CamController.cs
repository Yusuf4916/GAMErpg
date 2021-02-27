using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform Karakter;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Karakter.position.x,Karakter.position.y,transform.position.z);
    }
}
