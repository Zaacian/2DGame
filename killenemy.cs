using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killenemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public Rigidbody2D rbPlayer;
    public GameObject puff;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, 5); //?????????????
            Instantiate(puff, transform.position, transform.rotation);
            enemy.SetActive(false);
            AudioManager.instance.playHit();
        }
    }
}