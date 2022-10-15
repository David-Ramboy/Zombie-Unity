using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Default variables;
    [SerializeField] 
    // there are private cannot be access by other classes but they are visible in the inspector panel but you can change it in the inspector
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";
    public bool isMove = true;
    //- ------------------------- Updating

    bool isHurting;
    public bool facingRight = true;
    public delegate bool Died();
    public static Died died;

    private void Awake()
    {
        // this way only accessing by code
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
        Vector3 eulerRotation = transform.rotation.eulerAngles;

        // USE this or you can use Z rotation freeze in the inspector int constraint in the rigid body

       //transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        //print(eulerRotation);

    }

    private void FixedUpdate()
    {

    }

    public void PlayerMoveKeyboard()
    {
        if (died())
        {
            //Function for User Input
            // the position where key click if right or left
            movementX = Input.GetAxis("Horizontal");
            // deltaTime is basing to the Time of each Frame
            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        }
       

    }

    void AnimatePlayer()
    {
        //Function for Movement
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
            facingRight = true;
        }
        else if(movementX < 0){
            anim.SetBool(WALK_ANIMATION, true);

            sr.flipX = true;
            facingRight = false;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);

        }
    }

    void PlayerJump()
    {
        // GetButtonDown & GetButtonUp is how you pressed the button based on Down or Up  /down means is hold pressed down and Up is releasing the hold pressed
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
    
    //Built in function from monoBehaviour which allow as to detect collision between two game object
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;

        if (collision.gameObject.CompareTag(ENEMY_TAG))
            StartCoroutine("Hurt");
        //Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            StartCoroutine("Hurt");
        //Destroy(gameObject);
    }
    IEnumerator Hurt()
    {
        isHurting = true;
        myBody.velocity = Vector2.zero;

        if (facingRight)
        {
            myBody.AddForce(new Vector2(-200f, 200f));
        }
        else
        {
            myBody.AddForce(new Vector2(200f, 200f));
        }

        yield return new WaitForSeconds(0.5f);
        isHurting = false;
     }
   }
