using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class volume : MonoBehaviour {


    public AudioMixer audioMix;

    public void SeetVolume (float volume)
    {
        audioMix.SetFloat("Volume", volume);
    }

}
