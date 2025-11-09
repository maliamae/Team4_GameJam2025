using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 MovementInputVector { get; private set; }
    public bool jumpPressed;
    public Vector2 LookInputVector { get; private set;  }
    
    
    private void OnMove(InputValue inputValue)
    {
        MovementInputVector = inputValue.Get<Vector2>();
        //Debug.Log(MovementInputVector);

        if (MovementInputVector.x > 0.1f || MovementInputVector.y > 0.1f)
        {
            GetComponentInParent<PlayerAudioController>().walkingSource.Play();
        }
        else
        {
            GetComponentInParent<PlayerAudioController>().walkingSource.Pause();
        }
    }

    private void OnJump(InputValue inputValue)
    {
        //Debug.Log("Jump: " + inputValue.Get<float>());
        //JumpInputFloat = inputValue.Get<float>();
        jumpPressed = true;
    }

    private void OnLook(InputValue inputValue)
    {
        LookInputVector = inputValue.Get<Vector2>();
    }

}
