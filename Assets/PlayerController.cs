using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    private int count;
    private Animator animator;
    private SpriteRenderer sp;
    bool attackFinish = false; //Prevents animation from playing over and over from holding button down
    int timer = 0;

    private bool facingLeft = false; //This is so the flip checkboxes aren't being checked every frame
    private bool facingRight = true;

    //hitboxes
    public GameObject hitbox1;
     GameObject currentHitbox;

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>(); //get reference
        sp = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && attackFinish == false) {
            animator.SetTrigger("Player_Attack");
            //spawn hitboxes
            if (facingLeft == true) {
                currentHitbox = Instantiate(hitbox1, -transform.position, Quaternion.identity, this.transform);
            }
            else
           currentHitbox = Instantiate(hitbox1, transform.position, Quaternion.identity, this.transform);
            //after certain amount of time
            //Destroy(hitbox1);
            attackFinish = true;
        }

        if (Input.GetButtonUp("Fire1") && attackFinish == true)
        {
            Destroy(currentHitbox);
            attackFinish = false;
        }

        //sprite flipping
        if (Input.GetKeyDown("left") && facingLeft == false) {
            sp.flipX = true;
            facingRight = false;
            facingLeft = true;
        }

        if (Input.GetKeyDown("right") && facingRight == false)
        {
            sp.flipX = false;
            facingLeft = false;
            facingRight = true;
        }

        //if (Input.GetButtonUp("left") || Input.GetButtonUp("right"))
        //{
        //    StopMovement();
        //}


    }

    void FixedUpdate() {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement* speed);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("PickUp")) {
        
            other.gameObject.SetActive(false);
            count++;
            //SetCountText();

        }

    }

    void StopMovement() { //character will not do the slidy
        rb2d.isKinematic = true;
    }

    void attack(int hitNum)
    {

        switch (hitNum)
        {
            case 1:
                Instantiate(hitbox1,this.transform);
                break;
        }
    }
    
}
