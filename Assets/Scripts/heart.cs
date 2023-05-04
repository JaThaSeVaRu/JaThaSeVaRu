using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public bool inLove;
    public GameObject LovePose, IdlePose, Herz;

    public int heartValue;

    private BoxCollider2D boxCollider;
    //private Animator anim;
    void Awake()
    {
        Herz.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Start()
    {
        LovePose.GetComponent<SpriteRenderer>().enabled = false;
        IdlePose.GetComponent<SpriteRenderer>().enabled = true;
        Herz.GetComponent<SpriteRenderer>().enabled = false;

        boxCollider = GetComponent<BoxCollider2D>();
        //anim = GetComponent<Animator>();
        //anim.SetBool("Herz_getroffen", false);
    }

    public void Update()
    {
        heartValue = WinLoseScore.heartWorth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pose"))
        {
            if (inLove == false)
            {
                Debug.Log("Test");
                inLove = true;
                //Effekt
                LovePose.GetComponent<SpriteRenderer>().enabled = true;
                IdlePose.GetComponent<SpriteRenderer>().enabled = false;
                Herz.GetComponent<SpriteRenderer>().enabled = true;
                Herz.GetComponent<Animator>().Play("Herz_getroffen",0,0);
                //GameManager.Instance.player.CollectedHearts++;
                WinLoseScore.actualHearts++;
                WinLoseScore.score += heartValue;
                boxCollider.enabled = !boxCollider.enabled;
                //anim.SetBool("Herz_getroffen", true);
            }
        }
    }

}
