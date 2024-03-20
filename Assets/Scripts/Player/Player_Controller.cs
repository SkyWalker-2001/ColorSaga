using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 300;

    public GameObject character;

    private Rigidbody2D character_RigidBody2D;
    private SpriteRenderer character_Sprite_Renderer;
    private float screenWidth;

    private float facingDir = 1;

    private void Start()
    {
        screenWidth = Screen.width;
        character_RigidBody2D = character.GetComponent<Rigidbody2D>();
        character_Sprite_Renderer = character.GetComponent<SpriteRenderer>();
        character_Sprite_Renderer.flipX = true;
    }

    private void Update()
    {
        Flip_Controller();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        int i = 0;

        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > screenWidth / 2)
            {
                facingDir = 1;
                ClearMotion();
                RunCharacter(1.0f);
            }

            if (Input.GetTouch(i).position.x < screenWidth / 2)
            {
                facingDir = -1;
                ClearMotion();
                RunCharacter(-1.0f);
            }

            ++i;
        }
    }

   
    private void ClearMotion()
    {
        character_RigidBody2D.velocity = Vector2.zero;
    }

    private void RunCharacter(float horizontalInput)
    {
        if(character_RigidBody2D.velocity.x >= 3)
        {
            character_RigidBody2D.velocity = new Vector2(3,0);
            return;
        }
        
        if(character_RigidBody2D.velocity.x <= -3)
        {
            character_RigidBody2D.velocity = new Vector2(-3,0);
            return;
        }

        character_RigidBody2D.velocity = new Vector2(horizontalInput * moveSpeed,0);

        //character_RigidBody2D.AddForce(new Vector2(horizontalInput * moveSpeed, 0), ForceMode2D.Impulse);
    }

    private void Flip_Controller()
    {
        if (facingDir == 1)
        {
            Flip(true);
        }
        else if (facingDir == -1)
        {
            Flip(false);
        }
        else
        {
            return;
        }
    }

    private void Flip(bool FacingDir_Bool)
    {
        character_Sprite_Renderer.flipX = FacingDir_Bool;
    }
}
