using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeValue;

    private Coroutine _volumeChangerCoroutine;
    private float _volume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            if (_audioSource.isPlaying)
            {
                StopCoroutine(_volumeChangerCoroutine);
                _volumeChangerCoroutine = StartCoroutine(ChangeVolume(-_volumeChangeValue));
            }
            else
            {
                _audioSource.Play();
                _volumeChangerCoroutine = StartCoroutine(ChangeVolume(_volumeChangeValue));
            }
        }
    }

    private IEnumerator ChangeVolume(float changeValue)
    {
        if(changeValue > 0)
        {
            while (_volume < 1)
            {
                _volume += changeValue * Time.deltaTime;
                _audioSource.volume = _volume;
                yield return null;
            }
        }
        else
        {
            while(_volume > 0)
            {
                _volume += changeValue * Time.deltaTime;
                _audioSource.volume = _volume;
                yield return null;
            }
            _audioSource.Stop();
            StopCoroutine(_volumeChangerCoroutine);
        }
    } 
}
