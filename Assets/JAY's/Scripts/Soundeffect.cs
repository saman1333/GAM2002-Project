using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundeffect : MonoBehaviour {

    public AudioSource levelMusic;
    public AudioSource laugh;

    public bool levelsong = true;
    public bool laughing = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Levelmusic() {
        levelsong = true;
        laughing = false;
        levelMusic.Play();
    }

    public void DeathSound()
    {
        if (levelMusic.isPlaying)
            levelsong = false;
        {
            levelMusic.Stop();
        }
        if (!laugh.isPlaying && laughing == false)
        {
            laugh.Play();
            laughing = true;
        }
    }




}
