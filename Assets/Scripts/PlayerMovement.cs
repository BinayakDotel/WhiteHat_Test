using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;
    [SerializeField] float movement_sensitivity = 1f;
    [SerializeField] Transform player_body;
    [SerializeField] float mouse_pos_x, mouse_pos_y, x_rotate = 0f;
    [SerializeField] float horizontal, vertical;
    [SerializeField] float up_down_limit = 90f;
    [SerializeField] Vector3 velocity;
    public bool is_moving = false;
    public bool is_grounded;
    private void Update()
    {
        is_grounded = !controller.isGrounded;
        GetMousePositionAndAxis();
        MovePlayer();
        RotatePlayer();

        if (velocity.y < 0)
        {
            //print($"RESET");
            velocity.y = -2f;
        }
        GravitySimulator();
    }


    void GetMousePositionAndAxis()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
            is_moving = true;
        else
            is_moving = false;

        mouse_pos_x = Input.GetAxis("Mouse X") * movement_sensitivity * Time.deltaTime;
        mouse_pos_y = Input.GetAxis("Mouse Y") * movement_sensitivity * Time.deltaTime;
    }
    void MovePlayer()
    {
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        controller.Move(move * speed * Time.deltaTime);
    }
    void RotatePlayer()
    {
        x_rotate -= mouse_pos_y;
        x_rotate = Mathf.Clamp(x_rotate, -up_down_limit, up_down_limit);

        Camera.main.transform.localRotation = Quaternion.Euler(x_rotate, 0f, 0f);
        player_body.Rotate(Vector3.up * mouse_pos_x);
    }
    [SerializeField] float gravity = 9.81f;
    void GravitySimulator()
    {
        //print("GRAVITY WORKING");
        //Vector3 gravity = new Vector3(0f, -9.81f, 0f);
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
