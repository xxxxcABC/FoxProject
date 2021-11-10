using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour
{
    protected Animator anim;
    protected Collider2D coll;
    public bool IsCollecting;
    public int Score;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        coll = gameObject.GetComponent<Collider2D>();
    }


    public virtual int CountPlus() {
        return 0;
    }
    public virtual void Death() {
        this.IsCollecting = true;
        coll.enabled = false;
        anim.SetTrigger("Death");
    }
    public void DestroyItem() {
        Destroy(gameObject);
    }
}
