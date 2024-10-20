using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{   
    public GameManager gameMainScene;
    private void Start() 
    {
        gameMainScene = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<MainCharacter>())
        {
            gameMainScene.hudManager.ShowHideMessage("Coletou 3 recursos!", 1);
            gameMainScene.castle.ChangeResource(+3);
            Debug.Log("ganhou 3 res");
            Destroy(this.gameObject);
        }
    }
}
