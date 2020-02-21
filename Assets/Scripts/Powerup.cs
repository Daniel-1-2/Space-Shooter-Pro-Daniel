using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //0 = triple shot 1 = speed 2 = shilds
    [SerializeField]
    private int powerupID;
    [SerializeField]
    private float _speed = 3.0f;
    private AudioManager _audioManager;

    void Start ()
    {
        _audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        if (_audioManager == null)
        {
            Debug.LogError("The Audio Manager is NULL.");
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch(powerupID)
                {
                    case 0:
                    player.TripleShotActive();
                    break;
                    case 1:
                    player.SpeedBoostISActive();
                    break;
                    case 2:
                    player.ShieldsAreActive();
                    break;
                    default:
                    Debug.Log("Defalt Value");
                    break;
                }
            }
            _audioManager.PowerupSound();
            Destroy(this.gameObject);
        }
    }
}
