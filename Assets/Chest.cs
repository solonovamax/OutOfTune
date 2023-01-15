using UnityEngine;

public class Chest : MonoBehaviour, Interactable {
    // Start is called before the first frame update
    public  SpriteRenderer sr;
    public  Sprite         NewSprite;
    public  Collider2D     coll;
    private bool           canInteract;

    /*  private void OnCollisionExit2D(Collision2D other)
      {
          tag = "Player";
      }*/
    public void playerInteraction(Player player) {
        if (!canInteract)
            return;

        if (!Input.GetMouseButtonDown(0))
            return;

        Debug.Log("Interaction");

        // throw new System.NotImplementedException();
    }
}
