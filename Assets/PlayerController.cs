using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float topSpeed;
    public float acceleration;
    public float turnSpeed;
    public Sprite[] sprites;

    protected float currentSpeed = 0.0f;

    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 direction = new Vector2(0, 1);

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update () {
        bool accelerate = Input.GetKey("w");
        bool turnLeft = Input.GetKey("a");
        bool turnRight = Input.GetKey("d");
        bool deccelerate = Input.GetKey("s");
        print(direction);
        if (accelerate)
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration, topSpeed);
        }
        else if (deccelerate)
        {
            currentSpeed = Mathf.Max(currentSpeed - acceleration / 8, 0);
        }

        if (turnLeft)
        {
            direction = Quaternion.Euler(0, 0, turnSpeed) * direction;
        }
        if (turnRight)
        {
            direction = Quaternion.Euler(0, 0, -turnSpeed) * direction;
        }
        float angle = Mathf.Atan2(direction.y, direction.x);
        if (angle < Mathf.PI / 8 && angle > -Mathf.PI / 8)
        {
            // E
            spriteRenderer.sprite = sprites[3];
        }
        else if (angle < 3 * Mathf.PI / 8 && angle > Mathf.PI / 8)
        {
            spriteRenderer.sprite = sprites[7];
            // NE
        }
        else if (angle < 5 * Mathf.PI / 8 && angle > 3 * Mathf.PI / 8)
        {
            // N
            spriteRenderer.sprite = sprites[6];
        }
        else if (angle < 7 * Mathf.PI / 8 && angle > 5 * Mathf.PI / 8)
        {
            spriteRenderer.sprite = sprites[5];
            // NW
        }
        else if (angle < -7 * Mathf.PI/8 || angle > 7 * Mathf.PI / 8)
        {
            // W
            spriteRenderer.sprite = sprites[4];
        }
        else if (angle < -5 * Mathf.PI/8 && angle > -7 * Mathf.PI/8)
        {
            spriteRenderer.sprite = sprites[0];
            // SW
        }
        else if (angle < -3 * Mathf.PI/8 && angle > -5 * Mathf.PI/8)
        {
            spriteRenderer.sprite = sprites[1];
            // S
        }
        else if (angle < -1 * Mathf.PI / 8 && angle > -3 * Mathf.PI / 8)
        {
            spriteRenderer.sprite = sprites[2];
            // SE
        }

        rb2d.position = rb2d.position + direction * currentSpeed * Time.deltaTime;
    }
}
