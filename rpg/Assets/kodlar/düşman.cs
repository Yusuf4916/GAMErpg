using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class düşman : MonoBehaviour
{
    public Transform hedef;

    public bool deneme;

    public GameObject zopasag,zopasol,altın,item,karak;

    public Slider CanBarı;

    public float hiz;

    float mesafe;

    int rasgeleItem;

    Animator anim;

    Rigidbody2D rb;

    public int can=10;

    public int hasar=5;
  
    public Transform yeri;

    public bool donme=true;
    public bool don;

    void Start()
    {
        anim = GetComponent<Animator>();        
        rb=GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        #region yönü
        mesafe = Vector2.Distance(transform.position, hedef.position);

        if (mesafe < 6)
        {
            transform.position = Vector2.MoveTowards(transform.position, hedef.position, hiz * Time.deltaTime);
            anim.SetBool("iswalk",true);

            float yon = transform.position.x - hedef.transform.position.x;
            
            if (yon > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                zopasol.SetActive(true);
                zopasag.SetActive(false);
            }
            if (yon < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                zopasol.SetActive(false);
                zopasag.SetActive(true);
            }

            if (yon < 0 && mesafe < 2f)
            {
                anim.SetTrigger("sagzopa");
            }

            if (yon > 0 && mesafe < 2f)
            {
                anim.SetTrigger("solzopa");
            }
        }
        
        else
        {
            anim.SetBool("iswalk", true);
            if (donme)
            {
                rb.velocity= new Vector2(-hiz,rb.velocity.y);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                zopasol.SetActive(true);
                zopasag.SetActive(false);
            }
            if (!donme)
            {
                rb.velocity= new Vector2(hiz, rb.velocity.y);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                zopasol.SetActive(false);
                zopasag.SetActive(true);
            }
        }



        #endregion

        #region item düşürme
        if (can<=0)
        {
            karak.GetComponent<karakter>().kalanDusman++;
            can = 0;
            rasgeleItem = Random.Range(1, 4);
            if(rasgeleItem==1)
            {
                Instantiate(altın, yeri.position, yeri.rotation);
            }
            if (rasgeleItem == 2)
            {
                Instantiate(item, yeri.position, yeri.rotation);
            }
            if (rasgeleItem == 3)
            {
                Instantiate(altın, yeri.position, yeri.rotation);
                Instantiate(item, yeri.position, yeri.rotation);
            }
            gameObject.SetActive(false);
           
        }

        #endregion

        CanBarı.value = can;

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "don")
        {
            donme = !donme;
        }
    }
    
    public IEnumerator hasaral(int hasr)
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        can -= hasr;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void hasarrr(int hasaaaar)
    {
        StartCoroutine(hasaral(hasaaaar));
    }
    

}
