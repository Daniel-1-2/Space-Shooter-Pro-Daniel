using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSourceForExplosions;
    private AudioSource _audioSourceForPowerups;
    [SerializeField]
    private AudioClip _explodeSoundEffect;
    [SerializeField]
    private AudioClip _powerupSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        _audioSourceForExplosions = GameObject.Find("Explosions").GetComponent<AudioSource>();
        _audioSourceForPowerups = GameObject.Find("Powerups").GetComponent<AudioSource>();
        if (_audioSourceForExplosions == null)
        {
            Debug.LogError("The AudioSource for the Explosions is NULL.");
        }
        if (_audioSourceForPowerups == null)
        {
            Debug.LogError("The AudioSource for the Powerups is NULL.");
        }
    }

    public void ExplodeSound ()
    {
        _audioSourceForExplosions.clip = _explodeSoundEffect;
        _audioSourceForExplosions.Play();
    }

    public void PowerupSound ()
    {
        _audioSourceForPowerups.clip = _powerupSoundEffect;
        _audioSourceForPowerups.Play();
    }
}
