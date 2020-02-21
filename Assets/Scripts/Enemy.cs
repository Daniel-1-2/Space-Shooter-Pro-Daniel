using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    private Player _player;
    private Animator _anim;
    private AudioManager _audioManager;

    void Start() 
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        if (_player == null)
        {
            Debug.LogError("Player is NULL.");
        }
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Animator is NULL.");
        }
        if (_audioManager == null)
        {
            Debug.LogError("The AudioManager is NULL.");
        }
    }

    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement ()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6)
        {
            Vector3 enemySpawnPos = new Vector3(Random.Range(-9.5f, 9.5f), 6, 0);
            transform.position = enemySpawnPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_player != null)
            {
                _player.Damage();
            }
            _anim.SetTrigger("OnEnemyDeath");
            _audioManager.ExplodeSound();
            _speed = 0f;
            Destroy(this.gameObject, 2.8f);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null) 
            {
            _player.UpdateScore(10);
            }
            _audioManager.ExplodeSound();
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0f;

            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
        }
    }
}
