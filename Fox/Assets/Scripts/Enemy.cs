using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Collider2D coll;
    protected AudioSource deathAudio;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        deathAudio = GetComponent<AudioSource>();
    }

    public void JumpOn()
    {
        Destroy(gameObject);
    }

    public void death()
    {
        deathAudio.Play();
        anim.SetTrigger("death");
        coll.enabled = false;
    }
}
