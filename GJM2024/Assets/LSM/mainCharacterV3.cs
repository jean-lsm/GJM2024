using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainCharacterV3 : MonoBehaviour
{
    // public MainScene mainScene;
    
    public Transform groundReference;
    public Rigidbody rigidbody;
    public Animator animator;





    [Header("Movement")]
    public bool isGrounded;
    public float speed, jumpForce;
    public Transform myCamera;
    public Transform myCameraRotationReference;
    public GameObject CameraFPS, CameraTPS;

    [Header("Dash")]
    public int dashForce;
    public float dashTime = 10F;
    public int dragForce;

    [Header("Sound")]
    public AudioSource hit, attack, heal, walking, dash;




    public bool sight;


    void Start()
    {
        // mainScene = FindAnyObjectByType<MainScene>();
        myCamera = Camera.main.transform;
        sight = true;;
    }
    void Update()
    {

        // Dash();
        // Attack();
        // 
        
        // if(Input.GetKeyDown(KeyCode.E)) sight = true;
        // if(Input.GetKeyUp(KeyCode.E)) sight = false;
        sight = Input.GetKey(KeyCode.E);
        
        if(sight)
        {
            speed = 2;
            CameraFPS.SetActive(true);
            CameraTPS.SetActive(false);
            Movement2();
        }
        else
        {
            speed = 5;
            CameraFPS.SetActive(false);
            CameraTPS.SetActive(true);
            Movement();
        }
        

    }
    

    
    public void Movement2()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movementVector = new Vector3(horizontal, 0f, vertical);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y, transform.eulerAngles.z);



        movementVector = transform.TransformDirection(movementVector);
        rigidbody.velocity = movementVector * speed;

        if (movementVector.magnitude > 0.1f)
        {
            animator.SetTrigger("walk");
            animator.ResetTrigger("idle");
            walking.Play();
            Quaternion targetRotation = Quaternion.LookRotation(movementVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

            // animator.SetFloat("speed", adrenalineLevel/10);
        }
        else
        {
            animator.SetTrigger("idle");
            animator.ResetTrigger("walk");
            walking.Pause();
        }
    }

    
    
    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontal, 0f, vertical);
        // Vector3 testecam = new Vector3(myCamera.eulerAngles.x, 0, myCamera.eulerAngles.z);
        
        movementVector = myCameraRotationReference.TransformDirection(movementVector);

        rigidbody.velocity = movementVector * speed;
        
        if (movementVector.magnitude > 0.1f)
        {
            animator.SetTrigger("walk");
            animator.ResetTrigger("idle");
            walking.Play();
            // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementVector), Time.deltaTime * 10);
            
            Quaternion targetRotation = Quaternion.LookRotation(movementVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

        }
        else
        {
            animator.SetTrigger("idle");
            animator.ResetTrigger("walk");
            walking.Pause();
        }

        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        // {
        //     rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        //     isGrounded = false;
        //     rigidbody.drag = dragForce;
        // }
    }
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!animator.GetCurrentAnimatorStateInfo(1).IsName("punchAttack") && animator.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.0f)
            {
                animator.SetTrigger("attack");
                attack.Play();
            }

        }
    }
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 10);
            animator.SetTrigger("dash");
            animator.ResetTrigger("walk");
            animator.ResetTrigger("idle");
            StartCoroutine(_Dash());
            dash.Play();

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
    }
    

    public void EndGame(bool status)
    {
        if (status == false)
        {
            animator.SetTrigger("die");
        }

    }


}
