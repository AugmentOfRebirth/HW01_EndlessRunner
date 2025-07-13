using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //this is a variable for a rigidbody that is attached to the player
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public float InitialMovementSpeed = 1f;
    private float tempIMS;
    public float InitialMovementSpeedMult;
    public float jumpForce;
    private float inputHorizontal;
    //private bool grounded = false;
    //private int maxNumJumps;
    //private int numJumps;
    private bool canJump = false;
    private bool isJumping = false;
    private Animator playerAnimator;
    public GameManager gameManager;
    private PlayerScore playerScore;
    public GameObject redDeathSpawner;
    private Vector3 originalScale;
    Vector3 shrinkScale = new Vector3(0.5f, 0.5f, 1f);
    public float shrinkDuration = 10f;
    private Coroutine shrinkRoutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //I can only get this component using the following line of code
        //because the rigidbody2d is attached to the player
        //and this script is also attached to the player
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerScore = gameManager.GetComponent<PlayerScore>();

        originalScale = transform.localScale;
        //maxNumJumps = 1;
        //numJumps = 1;
        tempIMS = InitialMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        //if the player presses a move left, d move right
        //"Horizontal" is defined in the input section of the project settings
        //the line below will return:
        //0  - no button pressed
        //1  - right arrow or d pressed
        //-1 - left arrow or a pressed
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        

        if (inputHorizontal != 0 && !gameManager.isPaused)
        {
            

            if (InitialMovementSpeed < movementSpeed)
            {
                playerRigidBody.linearVelocity = new Vector2(InitialMovementSpeed * inputHorizontal, playerRigidBody.linearVelocity.y);
            }
            else
            {
                playerRigidBody.linearVelocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.linearVelocity.y);
            }


            InitialMovementSpeed += InitialMovementSpeedMult;

            //the linear velocity is not set unless moving to allow the ground to move the player
           

            
            flipPlayerSprite(inputHorizontal);

            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
            InitialMovementSpeed = tempIMS;
        }

        //Debug.Log(inputHorizontal);
    }

    private void flipPlayerSprite(float inputHorizontal)
    {
        if (inputHorizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRigidBody.linearVelocity = new Vector2(playerRigidBody.linearVelocity.x, jumpForce);
            isJumping = true;
            canJump = false;
        }

        // Shorten jump if released early
        if (Input.GetKeyUp(KeyCode.Space) && isJumping)
        {
            playerRigidBody.linearVelocity = new Vector2(playerRigidBody.linearVelocity.x, playerRigidBody.linearVelocity.y * 0.5f);
            isJumping = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.gameOver();
        }
        //else if (collision.gameObject.CompareTag("Score"))
        //{
        //    playerScore.setPlayerScore(50);
        //    Destroy(collision.gameObject);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            playerScore.setPlayerScore(50);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shrink"))
        {
            if (shrinkRoutine != null)
            {
                StopCoroutine(shrinkRoutine);
            }
            
            shrinkRoutine = StartCoroutine(shrink());
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("RedDeath"))
        {
            redDeathSpawner.SetActive(true);
            Destroy(collision.gameObject);
        }

    }

    IEnumerator shrink()
    {
        transform.localScale = shrinkScale;

        yield return new WaitForSeconds(shrinkDuration);

        transform.localScale = originalScale;
    }
}