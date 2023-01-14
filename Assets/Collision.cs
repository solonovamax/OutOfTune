using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour, Interactable {
    // Start is called before the first frame update
    public  SpriteRenderer sr;
    public  Sprite         NewSprite;
    public  Collider2D     coll;
    private bool           change;


    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("Interact")) {
            Debug.Log("working");

            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = NewSprite;
        }
    }

    private void interact(Collision2D player) {
        Debug.Log("Interaction");
    }
    /*  private void OnCollisionExit2D(Collision2D other)
      {
          tag = "Player";
      }*/
    public void playerInteraction(Player player) {
        Debug.Log("Interaction");

        // throw new System.NotImplementedException();
    }
}
