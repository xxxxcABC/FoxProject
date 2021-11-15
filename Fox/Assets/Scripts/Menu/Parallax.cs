using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float MoveSpeedX;
    public float MoveSpeedY;
    public bool LockY;
    private float positionx,positiony;
    // Start is called before the first frame update
    void Start()
    {
        positionx=gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LockY)
        {
            transform.position = new Vector2(positionx + cam.position.x * MoveSpeedX, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(positionx + cam.position.x * MoveSpeedX, positiony + cam.position.y * MoveSpeedY);
        }
    }
}
