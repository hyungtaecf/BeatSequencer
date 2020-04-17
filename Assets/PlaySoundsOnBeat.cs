using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsOnBeat : MonoBehaviour
{
    public SoundManager _soundManager;
    public AudioClip bassDrum, snare;
    public AudioClip[] _strum;
    int _randomStrum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BPM._beatFull)
        {
            _soundManager.PlaySound(bassDrum, 1);
            if (BPM._beatCountFull % 2 == 0)
            {
                _randomStrum = Random.Range(0, _strum.Length);
            }
        }
        if (BPM._beatD8 && BPM._beatCountD8 % 2 == 0)
        {
            _soundManager.PlaySound(snare, 0.1f);
        }
        if(BPM._beatD8 && (BPM._beatCountD8 % 8 == 2 || BPM._beatCountD8 % 8 == 4))
        {
            _soundManager.PlaySound(_strum[_randomStrum], 1);
        }
    }
    
}
