using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //this is a variable for a rigidbody that is attached to the player
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public float jumpForce;
    private float inputHorizontal;
    //private bool grounded = false;
    private int maxNumJumps;
    private int numJumps;
    private Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //I can only get this component using the following line of code
        //because the rigidbody2d is attached to the player
        //and this script is also attached to the player
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        maxNumJumps = 1;
        numJumps = 1;
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

        

        if (inputHorizontal != 0)
        {
            

            //the linear velocity is not set unless moving to allow the ground to move the player
            playerRigidBody.linearVelocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.linearVelocity.y);

            
            flipPlayerSprite(inputHorizontal);

            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
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
        if (Input.GetKey(KeyCode.Space) && numJumps <= maxNumJumps)
        {
            playerRigidBody.linearVelocity = new Vector2(playerRigidBody.linearVelocity.x, jumpForce);

            numJumps++;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Ground"))
        {
            //grounded = true;
            numJumps = 1;
        }
        //else if (collision.gameObject.CompareTag("Bat"))
        //{
        //    //restart the level
        //    SceneManager.LoadScene("Level01");
        //}


        //Debug.Log("Grounded");
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Grounded"))
    //    {
    //        grounded = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("DoubleJump"))
        //{
        //    maxNumJumps = 2;
        //    //Destroy(collision.gameObject);
        //}
        if (collision.gameObject.CompareTag("OB"))
        {
            //restart the level
            SceneManager.LoadScene("Level01");
        }
    }
}