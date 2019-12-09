using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactBad : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameObject explosion;
    public int scoreValue;
    public int totalHealth;

    private GameController gameController;
    private AudioSource audioSource;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Shield")
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Bolt")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }
    }
}