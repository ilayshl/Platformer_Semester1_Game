using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float horizontalDir;
    public float verticalDir;
    public bool isAirborne; //used to communicate with PlayerAnimator
    public bool isLanding = true;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpForce = 6f;
    [SerializeField] float crouchSlowMultiplier = 1.5f; //adjusts moveSpeed when player crouches;
    private bool isTouchingGround; //used for jump resets and ground collider child;
    private bool canMove;
    private Rigidbody2D rb;
    private PlayerAttack pAttack;
    private PlayerCollider pCollider;

    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAttack = GetComponent<PlayerAttack>();
        pCollider = GetComponent<PlayerCollider>();
        isLanding = false;
        canMove = false;
    }

    private void Start()
    {
        rb.velocity = new Vector3(0, -7, 0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        CheckForGround();
        if (pCollider.isDead || !canMove) { return; }
        InputManagement();
        CheckForJump();
        SwitchDirections();

    }

    void FixedUpdate()
    {
        if (pCollider.isDead || !canMove) { return; }
        Move();
    }

    public bool IsCrouching()
    {
        if (verticalDir < 0 && isTouchingGround)
            return true;
        else
            return false;
    }

    //Passes current input information to other methods
    void InputManagement()
    {
        horizontalDir = Input.GetAxisRaw("Horizontal");
        verticalDir = Input.GetAxisRaw("Vertical");
    }

    //Player jumps only if it is not jumping already AND Y input is pressed
    void CheckForJump()
    {
        if (isTouchingGround && verticalDir > 0 && !isAirborne && !isLanding)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
            isTouchingGround = false;
            isAirborne = true;
        }
    }

    //Uses previously set input data to set player's velocity
    void Move()
    {
        if (IsCrouching())
        {
            //move slower while crouching
            rb.velocity = new Vector2(horizontalDir * moveSpeed / crouchSlowMultiplier, rb.velocity.y);
            pCollider.SetCroucningCollider();
        }
        else
        {
            rb.velocity = new Vector2(horizontalDir * moveSpeed, rb.velocity.y);
            pCollider.SetStandingCollider();
        }

    }

    //Resets player's jump bool
    void CheckForGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.1f, groundLayer);
        if (colliders.Length > 0)
        {
            //Landing
            if (!isTouchingGround && isAirborne)
            {
                isLanding = true;
                Invoke("ResetIsLanding", 0.3f);
                isTouchingGround = true;
                isAirborne = false;
            }
        }
        else
        {
            isAirborne = true;
            isTouchingGround = false;
        }
    }

    //Flips player's gameObject including hitboxes
    void SwitchDirections()
    {
        if (horizontalDir < 0 && transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
        else if (horizontalDir > 0 && transform.localScale.x < 0)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }

    void ResetIsLanding()
    {
        isLanding = false;
        if (!canMove)
        {
            canMove = true;
        }
    }

    public void PlayerWon(int enemiesSlain, int score) {
        canMove=false;
        Debug.Log("Congratulations! You won! (better winning player feedback wip)");
        Debug.Log($"You've reached {score} units high!");
        Debug.Log($"Over this journey, you've slain {enemiesSlain} enemies.");
        Debug.Log("Press 'R' to play again or 'ESC' to quit the climb.");
    }
}
