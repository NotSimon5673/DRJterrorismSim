using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController controller;
    public Camera viewPoint;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 20.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float cH;
    private float cV;
    public float gravityScale = 5;
    float Horizontal;
    float Vertical;
    float jump = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        cH = Input.GetAxis("Mouse X");
        cV= Input.GetAxis("Mouse Y");
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            jump = 0;
        }

        Vector3 move = transform.right * Horizontal + transform.forward * Vertical ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && jump == 0)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jump = 1;
        }

        if (Input.GetButtonDown("Sprint"))
        {
            playerSpeed = 40.0f;
        }

        transform.Rotate(0,cH, 0);
        viewPoint.transform.Rotate(-cV,0, 0);
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}