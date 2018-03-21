using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    
    public GameObject movementAction;
    public float speed;

    private float diagonalSpeed;

    private bool movementState;

    void OnDestroy()
    {
        FileDump.CloseSession();
    }

    void Start () {
        FileDump.OpenSession();
        diagonalSpeed = Mathf.Sqrt(2) / 2 * speed;
    }

    void Update () {
        float horizontalSpeed = (Input.GetAxis("Horizontal") * (speed - Mathf.Abs(Input.GetAxis("Vertical")) * (speed - diagonalSpeed)));
        float verticalSpeed = (Input.GetAxis("Vertical") * (speed - Mathf.Abs(Input.GetAxis("Horizontal")) * (speed - diagonalSpeed)));
        
        if(movementState != (horizontalSpeed + verticalSpeed != 0))
        {
            foreach (SpriteAction sa in movementAction.GetComponentsInChildren<SpriteAction>())
            {
                sa.SetState(horizontalSpeed + verticalSpeed != 0);
            }
            movementState = (horizontalSpeed + verticalSpeed != 0);
        }

        Vector2 movement = new Vector2(horizontalSpeed, verticalSpeed);
        this.GetComponent<Rigidbody2D>().velocity = movement;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
	}

    
}
