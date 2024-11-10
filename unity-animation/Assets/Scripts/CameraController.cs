using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public int isInverted;
    public Rigidbody rb;

    public float rotationSpeed;
    
    private Vector3 inputDir;
    private bool invertY;


    void Start()
    {
        isInverted = PlayerPrefs.GetInt("InvertY");
        invertY = isInverted == 1;
    }

    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }

    public void InvertY(bool invert)
    {
        invertY = invert;
        PlayerPrefs.SetInt("InvertY", invert ? 1 : 0);
        PlayerPrefs.Save();
    }
}
