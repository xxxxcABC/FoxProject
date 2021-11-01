using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter_scripts : MonoBehaviour
{
    public GameObject Textobj;
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Textobj.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Textobj.SetActive(false);
        }
    }
}
