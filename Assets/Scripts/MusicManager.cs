using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioSource> backgroundPlaylist;
    public AudioSource curPlaying;
    public static bool wirePuzzleLoaded;
    public static bool pipePuzzleLoaded;

    bool playingMainSceneMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playingMainSceneMusic)
        {

        }
    }

    public void WirePuzzleLoaded()
    {

    }
    public void PipePuzzleLoaded()
    {

    }
}
