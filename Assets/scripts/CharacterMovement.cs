using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool moveLeft = false;
    private bool moveRight = false;

    void Update()
    {
        // Check if either left or right button is pressed, or both
        if (moveLeft)
        {
            MoveLeft();
        }
        else if (moveRight)
        {
            MoveRight();
        }
        else
        {
            StopMove();
        }
    }

    public void MoveLeft()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    // Call this method when the left button is pressed down
    public void StartMoveLeft()
    {
        moveLeft = true;
        // Ensure that moveRight flag is reset when left button is pressed
        moveRight = false;
    }

    // Call this method when the left button is released
    public void StopMoveLeft()
    {
        moveLeft = false;
    }

    // Call this method when the right button is pressed down
    public void StartMoveRight()
    {
        moveRight = true;
        // Ensure that moveLeft flag is reset when right button is pressed
        moveLeft = false;
    }

    // Call this method when the right button is released
    public void StopMoveRight()
    {
        moveRight = false;
    }

    // Call this method to stop the character movement
    public void StopMove()
    {
        moveLeft = false;
        moveRight = false;
    }
}
