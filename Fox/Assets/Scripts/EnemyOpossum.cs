using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOpossum : Enemy
{
    private Rigidbody2D rb;
    public bool IsFacingLeft =true;
    public float MoveSpeed;
    public Transform left, right;
    private float leftx, rightx;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        leftx = left.position.x;
        rightx = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (IsFacingLeft && gameObject.transform.position.x > leftx)
        {
            rb.velocity = new Vector2(-MoveSpeed, rb.velocity.y);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            IsFacingLeft = true;
        }
        else if (gameObject.transform.position.x < rightx)
        {
            rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            IsFacingLeft = false;
        }
    }
}
