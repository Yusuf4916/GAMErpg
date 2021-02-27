using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Ayarlar : MonoBehaviour
{
    public GameObject settingMenu,karakter;




    public void Settings()
    {
        karakter.GetComponent<karakter>().baslangıc = false;
        settingMenu.SetActive(true);
    }

    public void Anamenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Geri()
    {
        karakter.GetComponent<karakter>().baslangıc = true;
        settingMenu.SetActive(false);
    }

    public void tekrar()
    {
        SceneManager.LoadScene(1);
    }

    public void kalite(int KaliteKac)
    {
        PlayerPrefs.SetInt("Kalite", KaliteKac);
        QualitySettings.SetQualityLevel(KaliteKac);
    }

}
