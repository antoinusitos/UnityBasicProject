using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatializedSound : MonoBehaviour 
{
    private AudioSource _theAudioSource = null;

	public void Init()
    {
        _theAudioSource = gameObject.AddComponent<AudioSource>();
        _theAudioSource.playOnAwake = false;
        _theAudioSource.spatialBlend = 1; // set the audio source to 3D
    }

    public void Play(AudioClip theAudio)
    {
        _theAudioSource.PlayOneShot(theAudio);
    }
}
