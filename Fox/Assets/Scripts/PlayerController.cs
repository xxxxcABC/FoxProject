using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    public Collider2D bColl,hideColl;
    private Rigidbody2D rb;
    public float speed;
    public float jumpforce;
    public LayerMask ground;
    public Transform groundCheck,upCheck;
    public int count = 0;
    public Text text;
    private bool jumpPressed,crouchPressed;
    private bool isJump;
    public int jumpcount;
    public bool isGround;
    public AudioSource jumpAudio,collectAudio, hurtAudio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        if (!anim.GetBool("hurt"))
        {
            Move();
            crouch();
        }
        jump();
        SwitchAnim();
    }

    public void Update()
    {
        if (Input.GetButtonDown("crouch"))
        {
            crouchPressed = true;
        }
        if (Input.GetButtonUp("crouch")){
            crouchPressed = false;
        }
        if (Input.GetButtonDown("Jump") && jumpcount > 0)
        {
            jumpPressed = true;
        }
        
    }
    //移动//
    private void Move()
    {
        /*float a = Input.GetAxis("Horizontal");
        float b = Input.GetAxisRaw("Horizontal");
        if (a != 0)
        {
            rb.velocity = new Vector2(a * speed * Time.deltaTime, rb.velocity.y);
            anim.SetFloat("isRunning", Mathf.Abs(a));
        }

        if (b != 0)
        {
            transform.localScale = new Vector3(b, 1, 1);

        }
        if (Input.GetButtonDown("Jump") && bColl.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
            anim.SetBool("jumping", true);
        }*/
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);

        if (horizontalMovement != 0)
        {
            transform.localScale = new Vector3(horizontalMovement, 1, 1);
        }
        anim.SetFloat("isRunning", Mathf.Abs(horizontalMovement * speed));
        
    }
    //跳跃
    public void jump() {
        if (isGround)
        {
            isJump = false;
            jumpcount = 2;
        }
        else if (rb.velocity.y < -0.1f)
        {
            isJump = true;
        }
        if (jumpPressed && isGround) {
            jumpAudio.Play();
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            anim.SetBool("jumping", true);
            jumpcount--;
            jumpPressed = false;
        }
        
        else if (jumpPressed && jumpcount > 0 && isJump)
        {
            jumpAudio.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            anim.SetBool("jumping", true);
            jumpcount--;
            jumpPressed = false;
        }
    }
    //动画切换//
    private void SwitchAnim()
    {
        anim.SetBool("idling", false);
            if (anim.GetBool("jumping"))
        {
            
            if (rb.velocity.y <0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }

        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
        if (anim.GetBool("hurt") && Mathf.Abs(rb.velocity.x) < 0.1f)
        {
            anim.SetBool("hurt", false);
        }
        else if (bColl.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idling", true);
        }

    }
    //触发器交互
    private void OnTriggerEnter2D(Collider2D collision)
    {   //收集物品//
        
            if (collision.tag == "Collection")
            {
                collectAudio.Play();
                Collections colle = collision.gameObject.GetComponent<Collections>();
                if (!colle.IsCollecting)
                {
                    count += colle.CountPlus();
                }
                colle.Death();
                text.text = count.ToString();
            }
        
        //死亡触发
        if (collision.tag == "DeadLine")
        {
            AudioSource BackMusic = GetComponent<AudioSource>();
            BackMusic.enabled = false; 
            Restart();        }
    }
    //敌人交互//
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (anim.GetBool("falling"))
            {
                enemy.death();
                count++;
                rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
                anim.SetBool("jumping", true);
                text.text = count.ToString();
            }
            else if (!anim.GetBool("falling"))
            {
                hurtAudio.Play();
                if (rb.position.x < collision.transform.position.x)
                {
                    rb.velocity = new Vector2(-7, rb.velocity.y);
                    anim.SetBool("hurt", true);
                }
                else if (rb.position.x > collision.transform.position.x)
                {
                    rb.velocity = new Vector2(7, rb.velocity.y);
                    anim.SetBool("hurt", true);
                }
            }
        }
    }
    //趴下
    private void crouch()
    {
        if (Physics2D.OverlapCircle(upCheck.position, 0.1f, ground))
        {
            crouchPressed = false;
        }
        if (!Physics2D.OverlapCircle(upCheck.position, 0.1f, ground) && crouchPressed)
        {
                hideColl.enabled = false;
                anim.SetBool("crouching", true);

        }else if (!Physics2D.OverlapCircle(upCheck.position, 0.1f, ground) && !crouchPressed)
            {
                hideColl.enabled = true;
                anim.SetBool("crouching", false);
            }
        }
    //重置
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    }
