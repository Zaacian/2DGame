using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float speed;
    public float jump;

    public bool IsGround;
    public bool IsMoving;
    public LayerMask groundLayer;
    public int hp = 3;
    public bool isFlash = false;
    public static player instance;
    public GameObject footPlayer;


    public Collider2D IsGrounded { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        instance = this;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FilpSprite();   
        CheckGround();
        Jump();
        AnimePlayer();
    }
    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        IsMoving = (Input.GetAxisRaw("Horizontal") != 0);
        Debug.Log(rb.velocity.x);
    }
    void FilpSprite()
    {
        bool flip = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(flip)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
    void CheckGround()
    {
        IsGround = Physics2D.OverlapCircle(transform.position, 0.5f, groundLayer);

    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && IsGround && !isFlash)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            AudioManager.instance.playJump();
        }
      
    }
    void AnimePlayer()
    {
        animator.SetBool("IsMove", IsMoving);
        animator.SetBool("IsGround", IsGround);
    }
    public void getDamage()
    {
        hp--;
        AudioManager.instance.playenemyHit();
        isFlash = true;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        Physics2D.IgnoreLayerCollision(7, 8, true);
        StartCoroutine(Flash());

        if (hp <= 0)
            this.gameObject.SetActive(false);

    }


    IEnumerator Flash()
    {

        for (int n = 0; n < 10; n++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        rb.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;
        Physics2D.IgnoreLayerCollision(7, 8, false);
        isFlash = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isFlash)
        {
            getDamage();
        }
    }
    public void addHP()
    {
        hp++;
        if (hp > Gameplay.instance.maxHp)
            hp = Gameplay.instance.maxHp;

    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.75f, 0.0f, 0.0f, 0.75f);

        Gizmos.DrawSphere(footPlayer.transform.position, 0.1f);
    }
   
}
