using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class anaMenü : MonoBehaviour
{

    public GameObject bilgilendirme;

    public void Basla()
    {
        SceneManager.LoadScene(1);
    }

    public void bilgi()
    {
        bilgilendirme.SetActive(true);
    }
    public void  cıkıs()
    {
        Application.Quit();
    }

    public void geri()
    {
        bilgilendirme.SetActive(false);
    }
}
