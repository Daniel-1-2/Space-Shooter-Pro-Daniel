using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 3.0f;
    [SerializeField]
    private GameObject _explosionPrefab;
    private SpawnManager _spawnManager;
    private AudioManager _audioManager;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The SpawnManager is NULL.");
        }
        if (_audioManager == null)
        {
            Debug.LogError("The AudioManager is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Laser")
        {
            _audioManager.ExplodeSound();
            _spawnManager.StartSpawning();
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.25f);
            GameObject cloneExplosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(cloneExplosion, 3.0f);
        }
    }
}
