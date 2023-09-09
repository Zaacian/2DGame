using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{ 
    public int coin = 0;
    public int maxHp = 3;
    public static Gameplay instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    private void Awake()
    {
        instance = this;
    }

    public void getCoin(int getcoin)
    {
        coin += getcoin;
    }

    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartCoroutine(delayAction());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator delayAction()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

