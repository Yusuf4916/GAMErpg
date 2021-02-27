using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shop2 : MonoBehaviour
{
    
    public GameObject karak;

    public int defans1, cevik1, guc1;

    public Text defans2, cevık2, guc2;

    public void Start()
    {
        
    }

    public void Update()
    {
        defans2.text = defans1.ToString();
        cevık2.text = cevik1.ToString();
        guc2.text = guc1.ToString();
    }

    
    public void YuzukSatma()
    {
        if (karak.GetComponent<karakter>().yüzük > 0)
        {
            karak.GetComponent<karakter>().yüzük--;
            karak.GetComponent<karakter>().altın += 40;
        }
    }

    public void ElmasSatma()
    {
        if (karak.GetComponent<karakter>().elmas>0)
        {
            karak.GetComponent<karakter>().elmas--;
            karak.GetComponent<karakter>().altın += 100;
        }
    }

    public void defans()
    {
        if (karak.GetComponent<karakter>().altın >= 30)
        {
            if (defans1 <= 4)
            {
                karak.GetComponent<karakter>().altın -= 30;
                karak.GetComponent<karakter>().gidencan--;
                defans1++;
            }
        }
    }

    public void guc()
    {
        if (karak.GetComponent<karakter>().altın >= 50)
        {
            if (guc1 <= 4)
            {
                karak.GetComponent<karakter>().altın -= 50;
                karak.GetComponent<karakter>().hasarver+=5;
                guc1++;
            }
        }
    }

    public void cevik()
    {
        if (karak.GetComponent<karakter>().altın >= 20)
        {
            if (cevik1 <= 4)
            {
                karak.GetComponent<karakter>().altın -= 20;
                karak.GetComponent<karakter>().hiz++;
                karak.GetComponent<karakter>().zaman -= 0.5f;
                cevik1++;
            }
        }
    }


}
