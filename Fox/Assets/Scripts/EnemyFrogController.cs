using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrogController : Enemy
{
    private Rigidbody2D rb;
    public float speed;
    public Transform right, left,player;
    public bool isFacingleft = true;
    private float rightx, leftx;
    public float jumpforce;
    public LayerMask ground;
    // Start is called before the first frame update
    protected override void  Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        rightx = right.position.x;
        leftx = left.position.x;
        Destroy(right.gameObject);
        Destroy(left.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      SwitchAnim();
      Search();
    }
    private void Search()
    {
        float Distance = player.transform.position.x - gameObject.transform.position.x;
        if (Mathf.Abs(Distance) >= 10)
        {
            Move();
        }

        else if (transform.position.x < rightx && transform.position.x > leftx)
        {
            isFacingleft = player.transform.position.x < transform.position.x ? true : false;
            Move();

        }
    }
    private void Move()
    {
        if (isFacingleft&&rb.IsTouchingLayers(ground))
        {       rb.velocity = new Vector2(-speed , jumpforce);
                transform.localScale = new Vector3(1, 1, 1);
            if (transform.position.x < leftx)
            {
                isFacingleft = false;
            }
        }
        else if (!isFacingleft && rb.IsTouchingLayers(ground)) {
            rb.velocity = new Vector2(speed , jumpforce);
            transform.localScale = new Vector3(-1, 1, 1);
            if (transform.position.x > rightx) {
                isFacingleft = true;
            }
        }
    }

    private void SwitchAnim() {
        if (rb.velocity.y > 0.1f) {
            anim.SetBool("jumping", true);
            anim.SetBool("idling", false);
        }
        else if (rb.velocity.y > -0.1f){
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
    }
    
}
