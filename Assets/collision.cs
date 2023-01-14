using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;
    public UnityEngine.Sprite NewSprite;
    public Collider2D coll;
    private bool change;
    


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Interact")
        {
            Debug.Log("working");
           
            this.gameObject.GetComponentInChild<SpriteRenderer>().sprite = NewSprite;
        }
    }
  /*  private void OnCollisionExit2D(Collision2D other)
    {
        tag = "Player";
    }*/


}


