using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	private bool active;
    public string playerModel;
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
	public float xRotation;
    bool readyToJump;
    public string player;
    public float walkSpeed;
    public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    private Vector3 orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
	private Camera m_Camera;
  
   void Start()
   {
       // At the start, get access to the Rigidbody to control/apply forces
       rb = GetComponent<Rigidbody>();
	   rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
       //rb.freezerotation.z = true;
	   //rb.freezerotation.y = true;
       playerModel = "YogaBall";
	   player = "Hider";
       readyToJump = true;
	   PlayerPrefs.SetString("HiderFound","No");
       m_Camera = Camera.main;
   }

   void Update() {
       // ground check
       grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 1.0f, whatIsGround);
	   //Debug.Log(active.ToString());
	   //Debug.Log(player);
	   //Debug.Log(walkSpeed);
	   print(PlayerPrefs.GetString("PlayerModel"));
	   if (player == "Hider"){
			if (walkSpeed==2){
	   			active = true;
			}
			if (walkSpeed==3){
	   			active = false;
			}
	   }
	   if (player == "Seeker"){
			if (walkSpeed==2){
	   			active = false;
			}
			if (walkSpeed==3){
	   			active = true;
			}
	   }
       if (active){
            MyInput();
			SpeedControl();
       }

       // handle drag
       if (grounded){
           rb.drag = groundDrag;
       }
       else{
           rb.drag = 0;
       }
	   player = PlayerPrefs.GetString("PlayerForm");
	   
	   if (Input.GetMouseButtonDown(0) && player == "Seeker")
       	   {
           Vector3 mousePosition = Input.mousePosition;
           Ray ray = m_Camera.ScreenPointToRay(mousePosition);
           if (Physics.Raycast(ray, out RaycastHit hit))
           {
               // Use the hit variable to determine what was clicked on.
				if (hit.collider.gameObject.CompareTag ("SmallObject")) {
                        Destroy(hit.collider.gameObject);
                }
				if (hit.collider.gameObject.CompareTag ("Player")) {
						Destroy(hit.collider.gameObject);
						PlayerPrefs.SetString("HiderFound","Yes");
				}
           	}
       }
   }
   private void FixedUpdate()
   {   
   if (active){
       MovePlayer();
   }
   }

   private void MyInput()
   {
       horizontalInput = Input.GetAxisRaw("Horizontal");
       verticalInput = Input.GetAxisRaw("Vertical");
       
       // when to jump
       if(Input.GetKey(jumpKey) && readyToJump && grounded)
       {
           readyToJump = false;

           Jump();

           Invoke(nameof(ResetJump), jumpCooldown);
       }
   }

   private void MovePlayer()
   {
	   orientation = m_Camera.transform.forward;
	   orientation.y = 0f;
	   
       // calculate movement direction
       moveDirection = orientation * verticalInput + Quaternion.AngleAxis(90, Vector3.up) * orientation* horizontalInput;
       
       //transform.forward = moveDirection;
       // on ground
       if (grounded)
       {
           rb.AddForce(moveSpeed * 10f*moveDirection.normalized, ForceMode.Force);
           PlayerPrefs.SetString("HiderIsGrounded","Yes");
       }

       // in air
       else if (!grounded)
       {
           rb.AddForce(moveSpeed * 10f * airMultiplier * moveDirection.normalized, ForceMode.Force);
           PlayerPrefs.SetString("HiderIsGrounded","No");
       }
   }

   private void SpeedControl()
   {
       Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

       // limit velocity if needed
       if(flatVel.magnitude > moveSpeed)
       {
           Vector3 limitedVel = flatVel.normalized * moveSpeed;
           rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
       }
   }

   private void Jump()
   {
       // reset y velocity
       rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

       rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
   }
   private void ResetJump()
   {
       readyToJump = true;
   }
}
