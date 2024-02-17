using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7.5f;
    public Vector2 lookingDir = new(0, 0);
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
        
    void GetInput()
    {
        float xDir = 0, yDir = 0;
        /* 
         * We use ++ and -- so that if Up and Down, or Left and Right
         * are pressed, the player doesn't move, instead of jittering or
         * heading in a random direction.
         */

        if (Input.GetKey(KeyBinds.moveUp) || Input.GetKey(KeyBinds.moveUpAlt))
        {
            yDir++;
        }
        if (Input.GetKey(KeyBinds.moveDown) || Input.GetKey(KeyBinds.moveDownAlt))
        {
            yDir--;
        }
        if (Input.GetKey(KeyBinds.moveLeft) || Input.GetKey(KeyBinds.moveLeftAlt))
        {
            xDir--;
        }
        if (Input.GetKey(KeyBinds.moveRight) || Input.GetKey(KeyBinds.moveRightAlt))
        {
            xDir++;
        }
        
        if (Mathf.Abs(xDir) == Mathf.Abs(yDir)) // if both keys are held
        {
            // this will make the distance travelled = 1 instead of 1.414
            xDir *= 0.70710678118f;
            yDir *= 0.70710678118f;
        }
        lookingDir.Set(xDir, yDir);
    }

    // FixedUpdate is repeatedly called at a consistent rate, regardless of framerate
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (speed * Time.fixedDeltaTime * lookingDir));
    }

}
