using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;

    //jab bhi niche do line jaise variable define karo unhe start() me intialize karna na bhulo
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        //normalizing it so that force does not increase massively when distance between player and enemy is lot, normalizing decreases the maginitude but keeps same direction

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
