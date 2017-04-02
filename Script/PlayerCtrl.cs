using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCtrl : MonoBehaviour {



    
    //private Rigidbody2D myRigidBody;
    [SerializeField]
    private float movementSpeed;
    private bool facingRight;


    Vector2 theScale ;
    public Animator anim;
    

	// Use this for initialization
	void Start () {
        facingRight = true;
        theScale=transform.localScale;
        //myRigidBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
     {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        /* 
        if(horizontal != 0||vertical!=0)
        {
            anim.SetBool("idle",false);
            anim.SetBool("walk",true);
        }
        else{
             anim.SetBool("idle",true);
             anim.SetBool("walk",false);
        }
        */
        if (Input.GetKey(KeyCode.N))
        {
            SceneManager.LoadScene("ResultAndCareerPath");
        }
        //transform.Translate(horizontal*2*Time.deltaTime,vertical*2*Time.deltaTime,0);
        HandleMovement(horizontal, vertical);

        Flip(horizontal);
	}

    private void HandleMovement(float horizontal, float vertical) 
    {
        //myRigidBody.velocity = Vector2.left;
        //myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
        //transform.Translate(horizontal * movementSpeed, vertical * movementSpeed, 0);
        
        
        if(horizontal != 0||vertical!=0)
        {
            anim.SetBool("idle",false);
            anim.SetBool("walk",true);
        }
        else{
             anim.SetBool("idle",true);
             anim.SetBool("walk",false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }
        
    }

    private void Flip(float horizontal) {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
            facingRight = !facingRight;

            theScale= new Vector2 (-theScale.x,theScale.y);
            transform.localScale = theScale;
        }

    }
    private void  OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mondavid")
        {
            SceneManager.LoadScene("Battle_Scene");
        }
    }
}
