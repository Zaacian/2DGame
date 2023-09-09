using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject pop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gameplay.instance.getCoin(1);
            Instantiate(pop, transform.position, transform.rotation);
            this.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Player"))
        {
            Gameplay.instance.getCoin(1);

            Instantiate(pop, new Vector3(transform.position.x, transform.position.y,

            transform.position.z), Quaternion.identity);

            gameObject.SetActive(false);
            AudioManager.instance.playCoin();

        }
    }
}
