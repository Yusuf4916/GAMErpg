using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class karakter : MonoBehaviour
{
    
    
   Animator anim;

    public GameObject alışveriş,bilgilendirme,kazanma,kaybetme;

    Rigidbody2D rb;

    public Slider CanBarı;

    public Text Elmas;
    public Text Yüzük;
    public Text Altın;

    public AudioSource ses;
    public AudioClip[] sesOynat;


    public float hareket;
    public float hiz;
    public float ziphiz;
    public float Can=100;
    public float genislik;
    public float zaman;



    public int yüzük;
    public int elmas;
    public int altın;
    public int gidencan=10;
    public int hasarver=10;
    public int kalanDusman;



    public bool yerdemi,deneme,ShopOpen;
    public bool baslangıc = false;
   

    public LayerMask enemy;
    public Transform enemyWhere;
    public float enemyRange;
    public bool degdimi;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        yerdemi = false;
        ses = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if(Can>0)
        {
            Vector3 yonu = transform.localScale;
            bar();

            #region yürüme
            float hori = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(hori * hiz, rb.velocity.y);
            if (hori < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (hori > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }


            anim.SetFloat("yurume", Mathf.Abs(rb.velocity.x));


            #endregion

            #region zıplama
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Approximately(rb.velocity.y, 0))
            {

                rb.AddForce(Vector2.up * ziphiz, ForceMode2D.Impulse);

            }
            if (Mathf.Approximately(rb.velocity.y, 0))
            {
                anim.SetBool("yerdemi", false);
            }
            else
            {
                anim.SetBool("yerdemi", true);
            }

            #endregion

            #region Saldırı
            zaman -= Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && zaman < 0)
            {
                zaman = 1f;
                StartCoroutine(dusman());
                anim.SetTrigger("atak");
                ses.Play();
            }
            #endregion

            #region Shop
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShopOpen = false;
            }

            if (ShopOpen)
            {
                alışveriş.SetActive(true);
            }

            else
            {
                alışveriş.SetActive(false);
            }
            #endregion

            #region bilgilendirme
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                baslangıc = true;
                bilgilendirme.SetActive(false);
            }

            if (baslangıc)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            #endregion

            #region Kazanma
            if(kalanDusman==5)
            {
                kazanma.SetActive(true);
                baslangıc = false;
            }
            #endregion
        }
        else
        {
            Can = 0;
            StartCoroutine(Die());
            kaybetme.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zopa")
        {
            StartCoroutine(hasar());
        }

        if(collision.gameObject.tag=="dusman")
        {
            deneme = true;
        }
        if (collision.gameObject.CompareTag("elmas"))
        {
            elmas += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("yüzük"))
        {
            yüzük += 1;
            Destroy(collision.gameObject);
        }

    }

    IEnumerator hasar()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Can -= gidencan;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void bar()
    {
        CanBarı.value = Can;
        Yüzük.text = yüzük.ToString();
        Elmas.text = elmas.ToString();
        Altın.text = altın.ToString();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("elmas"))
        {
            elmas += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("yüzük") )
        {
            yüzük += 1;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("shop"))
        {
            ShopOpen = true;
        }

    }

    IEnumerator dusman()
    {
        Collider2D[] dusmanlar = Physics2D.OverlapCircleAll(enemyWhere.transform.position, enemyRange, enemy);
        foreach (Collider2D enemys in dusmanlar)
        {
            if (enemys.CompareTag("dusman"))
            {
                enemys.gameObject.GetComponent<düşman>().hasarrr(hasarver);
            }
        }
        yield return new WaitForSeconds(2f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(enemyWhere.position, enemyRange);
    }

    IEnumerator Die()
    {
        anim.SetTrigger("die");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
