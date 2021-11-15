using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Collider2D coll;
    protected AudioSource deathAudio;
    protected float AttackNumber;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        deathAudio = GetComponent<AudioSource>();
        AttackNumber = 2;
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

    public float Attack() {
        return AttackNumber;
    }
}
