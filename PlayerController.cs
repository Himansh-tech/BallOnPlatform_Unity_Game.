using System.Collections;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;

    public float powerUpStrength = 15.0f;
    public GameObject powerupIndicator;


    public bool hasPowerup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        float forwadInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(Vector3.forward * forwadInput * speed);
        playerRb.AddForce(focalPoint.transform.forward * forwadInput * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerupIndicator.gameObject.SetActive(true);
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupupCountdownRoutine());
        }
    }

    IEnumerator PowerupupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            
        }
    }

}
