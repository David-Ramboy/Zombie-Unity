using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // velocity forces the character to move left and right/ up and down
        
        // speed param is to be able to push player to move and myBody.velocity.y to move left and right because of Y-axis
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
