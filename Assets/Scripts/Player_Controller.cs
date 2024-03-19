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

    private void Start()
    {
        screenWidth = Screen.width;
        character_RigidBody2D = character.GetComponent<Rigidbody2D>();
        character_Sprite_Renderer = character.GetComponent<SpriteRenderer>();
        character_Sprite_Renderer.flipX = true;
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
                RunCharacter(1.0f);
                Flip(true);
            }

            if (Input.GetTouch(i).position.x < screenWidth / 2)
            {
                RunCharacter(-1.0f);
                Flip(false);
            }

            ++i;
        }
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
        
        character_RigidBody2D.AddForce(new Vector2(horizontalInput * moveSpeed, 0), ForceMode2D.Impulse);
    }


    private void Flip(bool FacingDir_Bool)
    {
        character_Sprite_Renderer.flipX = FacingDir_Bool;
    }
}
