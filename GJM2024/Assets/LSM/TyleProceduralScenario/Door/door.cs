using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public LevelManager levelManager;
    public bool closed, opening;
    public int timeToOpen = 15;
    public Animator animator;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponentInParent<LevelManager>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate()
    {
        StartCoroutine(_Operate());
        
    }

    IEnumerator _Operate()
    {
        // levelManager.mc.door = null;
        if (closed)
        {
            opening = true;
        }
        while(opening && timeToOpen > 0)
        {
            timeToOpen--;
            yield return new WaitForSeconds(1f);
        }
        animator.Play("open");
        audioSource.Play();
        closed = false;
        // levelManager.mc.RepleteOxygen(30);
        //this.gameObject.SetActive(false);
        yield return null;
    }
}
