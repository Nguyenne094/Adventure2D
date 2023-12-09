using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CheckDirection))]
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerControl playerControl;
    private Animator animator;
    private CheckDirection checkDirection;
    [SerializeField] private ParticleSystem dustStep;
    private Vector2 movement;

    public GameObject projectile;
    public Transform projectilePos;
    public uint cherry = 0;

    [Header("Setting")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;

    private bool _isRunning = false;
    private bool _isFacingRight = true;
    public Transform projectileParent;

    #region Properties

    public bool IsRunning { 
        get{
            return _isRunning;
        } 
        set{
            _isRunning = value;
            animator.SetBool(AnimationString.isRunning, value);
        }
    }

    public bool IsFacingRight { 
        get{
            return _isFacingRight;
        } 
        private set{
            if(_isFacingRight != value){
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        } 
    }
    #endregion

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        checkDirection = GetComponent<CheckDirection>();
        dustStep = GetComponentInChildren<ParticleSystem>();
        playerControl = new PlayerControl();
   }

   private void FixedUpdate() {
        Movement();
        if(IsRunning && checkDirection.IsGrounded)
            dustStep.Play();
   }

    private void Movement()
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    #region ActionMap Handle
    private void OnEnable() {
        playerControl.Player.Enable();
    }

    private void OnDisable() {
        playerControl.Player.Disable();
    }
    #endregion


    #region InputHandle
    public void OnMove(InputAction.CallbackContext ctx){
        movement = ctx.ReadValue<Vector2>();

        IsRunning = movement != Vector2.zero;

        FlipDirection(movement);
    }

    public void OnJump(InputAction.CallbackContext ctx){
        if(ctx.started && checkDirection.IsGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void OnFire(InputAction.CallbackContext ctx){
        if(ctx.started && cherry > 0){
            Instantiate(projectile, projectilePos.position, projectilePos.rotation, projectileParent);
            cherry--;
        }
    }
    #endregion

    private void FlipDirection(Vector2 moveInput){
        if(moveInput.x > 0 && !IsFacingRight){
            IsFacingRight = true;
        }
        else if(moveInput.x < 0 && IsFacingRight){
            IsFacingRight = false;
        }
        dustStep.Play();
    }
}
