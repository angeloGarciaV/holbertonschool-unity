using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Rigidbody rb;
    public PlayerController pc;
    public LayerMask isWall;

    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;
    private float climbTimer;

    private bool isClimbing;

    [Header("ClimbJump")]
    public float climbJumpForce;

    [Header("Detection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit hit;
    private bool wallFront;

    void Update()
    {
        WallCheck();
        StateMachine();

        if(isClimbing) ClimbingMovement();
    }

    private void StateMachine()
    {
        if(wallFront && Input.GetKey(KeyCode.W) && wallLookAngle < maxWallLookAngle)
        {
            if(!isClimbing && climbTimer > 0) StartClimb();
        
            if(climbTimer > 0) climbTimer -= Time.deltaTime;
            if(climbTimer < 0) StopClimbing();
        }
        else
        {
            if(isClimbing) StopClimbing();
        }

        if(wallFront && Input.GetKeyDown(pc.jumpKey)) ClimbJump();
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out hit, detectionLength, isWall);
        wallLookAngle = Vector3.Angle(orientation.forward, -hit.normal);

        // Draw the player's forward direction
        Debug.DrawLine(transform.position, transform.position + orientation.forward * detectionLength, Color.green);

        // Draw the wall normal
            Debug.DrawLine(hit.point, hit.normal * detectionLength, Color.red);

        if(pc.isGrounded)
        {
            climbTimer = maxClimbTime;
        }
    }

    private void StartClimb()
    {
        isClimbing = true;
    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    private void StopClimbing()
    {
        isClimbing = false;
    }

    private void ClimbJump()
    {
        Vector3 forceToApply = transform.up * climbJumpForce;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);
    }
}
