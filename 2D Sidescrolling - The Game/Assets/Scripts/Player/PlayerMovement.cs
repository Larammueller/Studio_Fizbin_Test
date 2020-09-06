using UnityEngine;

public class PlayerMovement : PlayerControls
{
    private float m_fDefaultWalkSpeed = 3.4f;
    [SerializeField]
    private float m_fWalkSpeed = 3.4f;
    [SerializeField]
    private float m_fRunSpeed = 5.4f;
    private float m_fMoveInput;
    public float fMoveInput
    {
        get { return m_fMoveInput; }
    }

    private Vector3 m_v3NewPos;
    private Rigidbody2D m_rbPlayer;

    private SpriteRenderer m_srPlayer;

    private bool m_bIsLookingRight;
    public bool bIsLookingRight
    {
        get { return m_bIsLookingRight; }
        set { m_bIsLookingRight = value; }
    }

    //for ground check
    private bool m_bIsGrounded;
    [SerializeField]
    private Transform m_transCheckGround;
    [SerializeField]
    private float m_fCheckGroundRadius;
    [SerializeField]
    private LayerMask m_lmGround;

    [SerializeField]
    private int m_iExtraJumpAmount = 1;
    private int m_iJumps;
    [SerializeField]
    private float m_fJumpForce = 10f;

    private bool m_bIsJumping = false;
    public bool bIsJumping
    {
        get { return m_bIsJumping; }
        set { m_bIsJumping = value; }
    }
    private bool m_bIsWalking = false;
    public bool bIsWalking
    {
        get { return m_bIsWalking; }
        set { m_bIsWalking = value; }
    }
    private bool m_bIsRunning = false;
    public bool bIsRunning
    {
        get { return m_bIsRunning; }
        set { m_bIsRunning = value; }
    }

    private void Awake()
    {
        this.m_rbPlayer = GetComponent<Rigidbody2D>();
        this.m_srPlayer = GetComponent<SpriteRenderer>();
        this.m_iJumps = this.m_iExtraJumpAmount;
        this.m_fCheckGroundRadius = 1f;
    }

    private void Start()
    {
        if(bIsPlayer1 == true)
        {
            this.m_bIsLookingRight = true;
        }
    }

    private void FixedUpdate()
    {
        Walk();
        Run();
        FlipPlayer();

        this.m_bIsGrounded = Physics2D.OverlapCircle(this.m_transCheckGround.position, this.m_fCheckGroundRadius, this.m_lmGround);

        if (this.m_bIsGrounded == true)
        {
            ResetJumps();
        }

        if (this.m_iJumps > 0)
        {
            Jump();
        }
    }

    private void Jump()
    {
        //player 1 jump
        if (bIsPlayer1 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.m_bIsJumping = true;
                this.m_rbPlayer.velocity = Vector2.up * this.m_fJumpForce;

                //Set jumping animation true
                //this.m_animatorPlayer.SetBool("bIsJumping", true);

                this.m_iJumps--;
            }
        }
    }

    //Resets the players extra jumps when hitting the ground
    private void ResetJumps()
    {
        this.m_bIsJumping = false;
        this.m_iJumps = this.m_iExtraJumpAmount;
    }

    private void Walk()
    {
        this.m_v3NewPos = transform.position;
        //move player 1
        if (bIsPlayer1 == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.m_bIsWalking = true;
                this.m_v3NewPos.x -= this.m_fWalkSpeed * Time.deltaTime;
                //lef = -1, right = 1
                this.m_fMoveInput = -1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.m_bIsWalking = true;
                this.m_v3NewPos.x += this.m_fWalkSpeed * Time.deltaTime;
                this.m_fMoveInput = 1f;
            }
            else
            {
                this.m_bIsWalking = false;
                this.m_fMoveInput = 0f;
            }
        }

        transform.position = this.m_v3NewPos;
    }

    private void Run()
    {
        if (bIsPlayer1 == true)
        {
            if (Input.GetKey(KeyCode.DownArrow) && this.m_bIsWalking == true)
            {
                this.m_bIsRunning = true;
                this.m_fWalkSpeed = this.m_fRunSpeed;
            }
            else
            {
                this.m_bIsRunning = false;
                this.m_fWalkSpeed = this.m_fDefaultWalkSpeed;
            }
        }
    }

    private void FlipPlayer()
    {
        //if player is looking right but starts moving left
        if (this.m_bIsLookingRight == true && this.m_fMoveInput < 0)
        {
            this.m_bIsLookingRight = !this.m_bIsLookingRight;
            m_srPlayer.flipX = true;
        }
        //if player is looking left but starts moving right
        if (this.m_bIsLookingRight == false && this.m_fMoveInput > 0)
        {
            this.m_bIsLookingRight = !this.m_bIsLookingRight;
            m_srPlayer.flipX = false;
        }
    }
}
