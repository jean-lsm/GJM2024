using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class MainCharacter : MonoBehaviour
{
    public GameManager gameMainScene;
    
    public Transform groundReference;
    public Rigidbody rigidbody;
    public Animator animator;





    [Header("Movement")]
    public bool isGrounded;
    public float speed, jumpForce;
    public Transform myCamera;
    public Transform myCameraRotationReference;
    public GameObject CameraFPS, CameraTPS;
    public PositionConstraint cameraConstraint;

    [Header("Dash")]
    public int dashForce;
    public float dashTime = 10F;
    public int dragForce;

    [Header("Sound")]
    public AudioSource hit, attack, heal, walking, dash;
    public bool sight;


    public GameObject ObjectPlace;
    public Object objectSelected;
    

    void Start()
    {
        gameMainScene = FindAnyObjectByType<GameManager>();
        sight = false;
    }
    void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {
            cameraConstraint.constraintActive = !cameraConstraint.constraintActive;
        }

        // if(sight)   // fps
        // {
        //     speed = 2;
        //     CameraFPS.SetActive(true);
        //     CameraTPS.SetActive(false);
        //     Movement1PS();
        // }
        // else // tps
        // {
        //     speed = 5;
        //     CameraFPS.SetActive(false);
        //     CameraTPS.SetActive(true);
        //     Movement3PS();
        // }

        // Jump();
        Movement3PSTopDown();
        // Dash();
        // Attack();
        

    }


    
    public void Movement1PS()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontal, 0f, vertical);
        
        // transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y, transform.eulerAngles.z);
        
        

        movementVector = myCamera.TransformDirection(movementVector);
        movementVector.y = 0;
        rigidbody.velocity = movementVector * speed;


        Quaternion targetRotation = Quaternion.LookRotation(movementVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

        if (movementVector.magnitude > 0.1f)
        {
            // animator.SetTrigger("walk");
            // animator.ResetTrigger("idle");
            // walking.Play();
            // Quaternion targetRotation = Quaternion.LookRotation(movementVector);
            // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime);

            // animator.SetFloat("speed", adrenalineLevel/10);
        }
        else
        {
            // animator.SetTrigger("idle");
            // animator.ResetTrigger("walk");
            // walking.Pause();
        }
    }
    
    public void Movement3PS()
    {
        if(!isGrounded) return;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontal, rigidbody.velocity.y, vertical);
        
        movementVector = myCamera.TransformDirection(movementVector);
        movementVector.y = rigidbody.velocity.y;
        rigidbody.velocity = movementVector * speed;
        
        if (movementVector.magnitude > 0.1f)
        {
            // animator.SetTrigger("walk");
            // animator.ResetTrigger("idle");
            // walking.Play();
            
            Quaternion targetRotation = Quaternion.LookRotation(movementVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

        }
        else
        {
            // animator.SetTrigger("idle");
            // animator.ResetTrigger("walk");
            // walking.Pause();
        }

        
    }

    public void Movement3PSTopDown()
    {
        if(!isGrounded) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontal, 0, vertical);
        
        // movementVector = myCamera.TransformDirection(movementVector);
        // movementVector.y = rigidbody.velocity.y;
        rigidbody.velocity = movementVector * speed;
        
        if (movementVector.magnitude > 0.1f)
        {
            // animator.SetTrigger("walk");
            // animator.ResetTrigger("idle");
            // walking.Play();
            
            Quaternion targetRotation = Quaternion.LookRotation(movementVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

        }
        else
        {
            // animator.SetTrigger("idle");
            // animator.ResetTrigger("walk");
            // walking.Pause();
        }

        
    }

    public void Movement3PS_Tank()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movementVector = new Vector3(horizontal, 0f, vertical);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y, transform.eulerAngles.z);



        movementVector = transform.TransformDirection(movementVector);
        rigidbody.velocity = movementVector * speed;

        if (movementVector.magnitude > 0.1f)
        {
            // animator.SetTrigger("walk");
            // animator.ResetTrigger("idle");
            // walking.Play();
            Quaternion targetRotation = Quaternion.LookRotation(movementVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

            // animator.SetFloat("speed", adrenalineLevel/10);
        }
        else
        {
            // animator.SetTrigger("idle");
            // animator.ResetTrigger("walk");
            // walking.Pause();
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // rigidbody.velocity = Vector3.up * jumpForce;
            isGrounded = false;
            // rigidbody.drag = dragForce;
            Debug.Log("pulo");
        }
    }
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!animator.GetCurrentAnimatorStateInfo(1).IsName("punchAttack") && animator.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.0f)
            {
                animator.SetTrigger("attack");
                // attack.Play();
            }

        }
    }
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 10);
            // animator.SetTrigger("dash");
            // animator.ResetTrigger("walk");
            // animator.ResetTrigger("idle");
            StartCoroutine(_Dash());
            // dash.Play();

            Quaternion targetRotation = Quaternion.LookRotation(transform.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 1000000);
        }

    }
    IEnumerator _Dash()
    {
        // mainScene.timeSunrise -= 10;
        for (int i = 0; i < dashTime; i++)
        {
            // Quaternion targetRotation = Quaternion.LookRotation(mainCamera.transform.localEulerAngles);
            // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3);
            yield return new WaitForSeconds(Time.deltaTime);
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movementVector = new Vector3(horizontal, 0f, vertical);
            movementVector = groundReference.TransformDirection(movementVector);
            rigidbody.AddForce(movementVector * dashForce);
            // rigidbody.AddForce(new Vector3(mainCamera.forward.x, 0, mainCamera.forward.z) * dashForce);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.GetComponent<ColliderTriggerId>().id == "game end")
        // {
        //     mainScene.Endgame(true);
        // }

        // if (other.GetComponent<ColliderTriggerId>().id == "power up")
        // {
        //     mainScene.GainTime(120);
        //     Destroy(other.gameObject);
        // }

        if (other.gameObject.name == "ground")
        {
            isGrounded = true;
            Debug.Log("chão");
        }
    }

    

    public void EndGame(bool status)
    {
        if (status == false)
        {
            animator.SetTrigger("die");
        }

    }

    public void TeleportPlayer(GameObject destiny)
    {
        transform.position = destiny.transform.position;
    }

}
