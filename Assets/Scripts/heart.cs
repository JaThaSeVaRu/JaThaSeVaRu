using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public bool inLove;
    public GameObject LovePose, IdlePose, Herz;
    //private Animator anim;
    void Start()
    {
        LovePose.GetComponent<SpriteRenderer>().enabled = false;
        IdlePose.GetComponent<SpriteRenderer>().enabled = true;
        Herz.GetComponent<SpriteRenderer>().enabled = false;
        //anim = GetComponent<Animator>();
        //anim.SetBool("Herz_getroffen", false);
    }

    void Update()
    {
        
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
                //anim.SetBool("Herz_getroffen", true);
            }
        }
    }
}
