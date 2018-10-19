using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
 
public class relativeCameraMoveScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    Vector3 movement;
    Vector3 movementRotation;

    public Vector3 jump;
    public float jumpForce;
    public float gravity;
    public float jumpModifier;

    public Camera gamecam;
    private float directionSpeed = 3.0f;

    private float moveHorizontal;
    private float moveVertical;
    private float speedPlus = 0.0f;
    private float direction = 0f;
    private Vector3 moveDirection;

    public bool isGrounded = true;

    private Vector3 curLoc;
    private Vector3 prevLoc;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Physics.gravity = new Vector3(0, -gravity, 0);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void FixedUpdate()
    {
        ControllPlayer();
        StickToWorldspace(this.transform, gamecam.transform, ref direction, ref speedPlus);
    }

    void ControllPlayer()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Debug.Log(direction);
        movementRotation = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (isGrounded == true)
        {
            // Current movement
            rb.velocity = new Vector3(moveHorizontal, 0f, moveVertical).normalized * speed;
        }
        else
        {
            rb.AddForce(movementRotation * speed * jumpModifier);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button1) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 12.0f, rb.velocity.z);
            isGrounded = false;
        }


        if (movementRotation.sqrMagnitude > 0.1f && isGrounded)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementRotation), 1F);
        }

    }

    public void StickToWorldspace(Transform root, Transform camera, ref float directionOut, ref float speedOut)
    {

        Vector3 rootDirection = root.forward;

        Vector3 stickDirection = new Vector3(moveHorizontal, 0, moveVertical);

        speedOut = stickDirection.sqrMagnitude;

        Vector3 CameraDirection = camera.forward;
        CameraDirection.y = 0.0f;
        Quaternion referentialShift = Quaternion.FromToRotation(rootDirection, Vector3.Normalize(CameraDirection));

        moveDirection = referentialShift * stickDirection;
        Vector3 axisSign = Vector3.Cross(moveDirection, rootDirection);

        // Will always face opposite to the camera
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 5f, root.position.z), moveDirection, Color.green);
        //Direction the player is facing
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 5f, root.position.z), rootDirection, Color.magenta);

        // Creates Angle between the two
        float angleRootToMove = Vector3.Angle(rootDirection, moveDirection);

        //        angleRootToMove /= 180f;

        directionOut = angleRootToMove;
        Debug.Log(directionOut);
    }
}
