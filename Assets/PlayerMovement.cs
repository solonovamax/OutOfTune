using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;
    float HInput;
    float VInput;
    public Animator anim;
    public SpriteRenderer sr;
    private float nowtime = 0;
    private float lasttime;
    public float delay = 1f;
   /* private float delay2 = 0.0f;*/
    private float lasttime2;
    private bool mouse = false;
    public BoxCollider2D bc;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
       HInput = Input.GetAxis("Horizontal");
        VInput = Input.GetAxis("Vertical");
        if (HInput != 0 || VInput != 0)
        {
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
        nowtime = Time.time;


      /*  if (Input.GetMouseButtonDown(0) && nowtime - lasttime2 > delay2)
        { mouse= true;
            delay2 = 0.8f;
        }
        else { mouse = false; }*/

       if (Input.GetMouseButtonDown(0))
        { 
            anim.SetBool("Trigger", true);
            bc.enabled = true;
            lasttime = nowtime;
        }
        if(nowtime-lasttime > delay)
        {
            anim.SetBool("Trigger", false);
            bc.enabled = false;
        }


        if (mouse)
        {
            anim.SetBool("Trigger", true);
            bc.enabled = true;
            lasttime = nowtime;
        }
        if (nowtime - lasttime > delay)
        {
            anim.SetBool("Trigger", false);
            bc.enabled = false;
        }
    }

    void FixedUpdate()
    {

        transform.position = transform.position + new Vector3(HInput * speed * Time.deltaTime, VInput * speed * Time.deltaTime, 0);



        if (HInput < 0 || VInput < 0)
        {
            sr.flipX = true;

        }
        else
        {
            sr.flipX = false;
        }



    }
}
