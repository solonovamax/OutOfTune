using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour {
    public float playerSpeed = 5f;

    public Rigidbody2D    rb;
    public Animator       anim;
    public SpriteRenderer sr;

    public  BoxCollider2D bc;
    private float         _hInput;
    private float         _vInput;

    // private static readonly int   animSpeedParameter    = Animator.StringToHash("Speed");
    private static readonly int animIsMovingParameter    = Animator.StringToHash("IsMoving");
    private static readonly int animIsAttackingParameter = Animator.StringToHash("IsAttacking");

    /// <summary>
    ///     Called once per frame
    /// </summary>
    private void Update() {
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");

        anim.SetBool(animIsMovingParameter, _hInput >= 0.1 || _hInput <= -0.1 || _vInput >= 0.1 || _vInput <= -0.1);
        anim.SetBool(animIsAttackingParameter, Input.GetMouseButtonDown(0));
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Interactable")) {
            var interactable = other.gameObject.GetComponent<Interactable>();

            interactable?.playerInteraction(this);
            // other.gameObject.BroadcastMessage("interact", this);
        }
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     Debug.Log(other.gameObject.tag);
    //
    //     if (other.gameObject.CompareTag("Interact")) {
    //         Debug.Log("working");
    //
    //         gameObject.GetComponentInChildren<SpriteRenderer>().sprite = NewSprite;
    //     }
    // }

    private void FixedUpdate() {
        transform.position += new Vector3(_hInput * playerSpeed * Time.deltaTime, _vInput * playerSpeed * Time.deltaTime, 0);
        if (_hInput > 0.01 || _vInput > 0.01)
            sr.flipX = false;
        else if (_hInput < 0.01 || _vInput < 0.01)
            sr.flipX = true;
        // else
        //     sr.flipX = false;


        // if (_hInput < 0 || _vInput < 0)
        //     sr.flipX = true;
        // else
        //     sr.flipX = false;
    }
}
