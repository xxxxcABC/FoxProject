using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagleController : Enemy
{
    private Rigidbody2D rb;
    public float flyforce;
    public Transform top;
    private float topy, downy;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<Collider2D>();
        topy = top.transform.position.y;
        downy = gameObject.transform.position.y;
        Destroy(top.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        fly();
    }

    private void fly() {
        if (transform.position.y > topy&&rb.velocity.y>0.1f) {
            rb.velocity = new Vector2(rb.velocity.x, -flyforce);
        }
        else if(transform.position.y < downy&&rb.velocity.y<-0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, flyforce);
        }
    }
}
