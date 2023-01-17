using UnityEngine;

public class Chest : MonoBehaviour, Interactable {
    // Start is called before the first frame update
    public  SpriteRenderer sr;
    public  Sprite         NewSprite;
    public  Collider2D     coll;
    private bool           canInteract;

    public void playerInteraction(PlayerController playerController) {
        if (!canInteract)
            return;

        if (!Input.GetMouseButtonDown(0))
            return;

        Debug.Log("Interaction");

        // throw new System.NotImplementedException();
    }
}
