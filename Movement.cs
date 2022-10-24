using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    PlayerInfo playerspeed;
    [SerializeField, Range(1, 50)]
    public float speed = 100;
    private Vector3 Direction;
    [SerializeField, Range(0.1f, 0.5f)]
    private float maxRotSpeed = 0.3f;
    [SerializeField]
    private float @ref;
    [SerializeField]
    private float gravity = 10f;
    [SerializeField]
    private Transform camera;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerspeed = GetComponent<PlayerInfo>();
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Direction = new Vector3(x, 0, z).normalized;
    }
    private void FixedUpdate()
    {
        
        if (Direction.magnitude >= 0.1f)
        {
            //kalo gerak
            float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref @ref, maxRotSpeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            float tempSpeedY = moveDirection.y;
            moveDirection = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            //
            moveDirection = moveDirection.normalized * speed * playerspeed.getAGI();

            moveDirection.y = tempSpeedY;
        }
        else moveDirection.x = moveDirection.z = 0;
        //kalo idle
        moveDirection.y -= gravity;
        controller.Move(moveDirection * Time.fixedDeltaTime);
    }
}
