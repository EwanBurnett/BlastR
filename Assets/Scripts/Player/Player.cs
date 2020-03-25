using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Default")]
    public float Speed;
    public MovementStates MoveMode;
    public Vector3 Movement;
    Rigidbody rb;
    Camera maincamera;

    [Space]

    [Header("Camera Anchors")]
    public float TransitionSpeed = 2f;
    public GameObject Anchor_X;
    public GameObject Anchor_Y;
    public GameObject Anchor_Z;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maincamera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (MoveMode)
        {
            case(MovementStates.Side):
                SideMove();
                break;
            case (MovementStates.Top):
                TopMove();
                break;
            case (MovementStates.Back):
                BackMove();
                break;

            default:
                break;
                
        }
    }

    void SideMove()
    {
        CameraTransition(Anchor_Z, new Quaternion(0f, -180f, 0f, 0f));

        float h = Input.GetAxisRaw("Horizontal") * Speed;
        float v = Input.GetAxisRaw("Vertical") * Speed;

        Movement = new Vector3(h, v, 0);
        rb.transform.Translate(Movement);
    }

    void TopMove()
    {
        CameraTransition(Anchor_Y, new Quaternion(0f, 0f, 90f, 0f));
    }

    void BackMove()
    {
        CameraTransition(Anchor_X, new Quaternion(0f,0f,0f,0f));
    }

    void CameraTransition(GameObject Anchor, Quaternion Rotation)
    {
        maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, Anchor.transform.position, Time.deltaTime * TransitionSpeed);
        //maincamera.transform.rotation = Quaternion.Lerp(maincamera.transform.rotation, Rotation, Time.deltaTime * TransitionSpeed);
    }
}

public enum MovementStates
{
    Side,
    Top,
    Back
}