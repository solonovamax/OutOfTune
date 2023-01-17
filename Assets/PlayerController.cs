using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour {
    private static readonly int   animIsMovingParameter    = Animator.StringToHash("IsMoving");
    private static readonly int   animIsAttackingParameter = Animator.StringToHash("IsAttacking");
    public                  float playerSpeed              = 5f;

    public Animator animator;

    [FormerlySerializedAs("sr")]
    public SpriteRenderer spriteRenderer;

    private float _hInput;
    private float _vInput;

    /// <summary>
    ///     Called once per frame
    /// </summary>
    private void Update() {
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");

        animator.SetBool(animIsMovingParameter, _hInput >= 0.1 || _hInput <= -0.1 || _vInput >= 0.1 || _vInput <= -0.1);
        animator.SetBool(animIsAttackingParameter, Input.GetMouseButtonDown(0));
    }

    private void FixedUpdate() {
        transform.position += new Vector3(_hInput * playerSpeed * Time.deltaTime, _vInput * playerSpeed * Time.deltaTime, 0);

        if (_hInput > 0.01 || _vInput > 0.01)
            spriteRenderer.flipX = false;
        else if (_hInput < 0.01 || _vInput < 0.01)
            spriteRenderer.flipX = true;
        // else
        //     sr.flipX = false;


        // if (_hInput < 0 || _vInput < 0)
        //     sr.flipX = true;
        // else
        //     sr.flipX = false;
    }

    private void OnTriggerStay2D(Collider2D other) {
        var interactable = other.gameObject.GetComponent<Interactable>();

        interactable?.playerInteraction(this);
    }
}
