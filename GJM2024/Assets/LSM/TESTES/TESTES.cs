using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TESTES : MonoBehaviour
{

    public GameObject teste;
    public float a;
    public bool grounded;
    public GameObject cameraTeste;
    public GameObject bullet;
    public UnityEvent[] testeEvento;
    public UnityEvent m_MyEvent = new UnityEvent();

    private void Start()
    {
        m_MyEvent.AddListener(MyAction);
    }

    
    private void Update()
    {
        Move();
        Rotate();
        Shoot();
        if(Input.GetKey(KeyCode.LeftShift))
        {
            a = 200;
            
        }
        else
        {
            a = 100;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            testeEvento[0].Invoke();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            testeEvento[1].Invoke();
        }
        // if (Input.GetKeyDown("q") && m_MyEvent != null)
        // {
        //     Debug.Log("Quitting");
        //     m_MyEvent.RemoveListener(MyAction);

        //     #if UNITY_EDITOR
        //     //UnityEditor.EditorApplication.isPlaying = false;
        //     #endif

        //     //Application.Quit();
        // }

        // //Press any other key to begin the action if the Event exists
        // if (Input.anyKeyDown && m_MyEvent != null)
        // {
        //     //Begin the action
        //     m_MyEvent.Invoke();
        // }
    }

    void MyAction()
    {
        //Output message to the console
        Debug.Log("Do Stuff");
    }
    
    

    public GameObject spawnBulletPoint;
    public GameObject spawnBulletPoint1, spawnBulletPoint2, spawnBulletPoint3;
    public void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, spawnBulletPoint.transform.position, this.gameObject.transform.rotation,this.gameObject.transform);
        }
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
        {
            Instantiate(bullet, spawnBulletPoint1.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
            //Instantiate(bullet, spawnBulletPoint2.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
            Instantiate(bullet, spawnBulletPoint3.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
        }
        
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            teste.GetComponent<Rigidbody>().AddForce(0, 0, a);
        }
        if (Input.GetKey(KeyCode.S))
        {
            teste.GetComponent<Rigidbody>().AddForce(0, 0, -a);
        }
        if (Input.GetKey(KeyCode.A))
        {
            teste.GetComponent<Rigidbody>().AddForce(-a, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            teste.GetComponent<Rigidbody>().AddForce(a, 0, 0);
        }
        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            teste.GetComponent<Rigidbody>().AddForce(0, -a, 0);
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded)
            {
                teste.GetComponent<Rigidbody>().AddForce(0, a * 100, 0);
            }
        }
    }
    public void Rotate()
    {
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            teste.GetComponent<Transform>().Rotate(-a, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            teste.GetComponent<Transform>().Rotate(a, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            teste.GetComponent<Transform>().Rotate(0, 0, a);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            teste.GetComponent<Transform>().Rotate(0, 0, -a);
        }*/
        if (Input.GetAxis("Mouse X") != 0)
        {
            cameraTeste.GetComponent<Transform>().Rotate(0, Input.GetAxis("Mouse X"), 0);
        }
        /*if (Input.GetAxis("Mouse Y") != 0)
        {
            camera.GetComponent<Transform>().Rotate(Input.GetAxis("Mouse Y"), 0, 0);
        }*/

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter collider");
        if (collision.gameObject.name == "ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit  collider");
        if (collision.gameObject.name == "ground")
        {
            grounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("stay collider");
        /*if (collision.gameObject.name == "ground")
        {
            grounded = true;
        }*/
    }
}
