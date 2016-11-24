using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioClip[] horde1audio;
    public AudioClip[] horde2audio;
    public AudioClip[] horde3audio;
    public AudioClip[] endBoss;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    
    public AudioClip getAudio(string sound)
    {
        AudioClip clip = null;
        //Horde1
        if (sound == "brussel") clip = horde1audio[0];
        if(sound == "donker")clip = horde1audio[1];
        if (sound == "fantasie") clip = horde1audio[2];
        if (sound == "glimlach") clip = horde1audio[3];
        if (sound == "lepeltje") clip = horde1audio[4];

        //Horde2
        if (sound == "camera") clip = horde2audio[0];
        if (sound == "elleboog") clip = horde2audio[1];
        if (sound == "geloof") clip = horde2audio[2];
        if (sound == "medewerking") clip = horde2audio[3];
        if (sound == "personeel") clip = horde2audio[4];
        if (sound == "woordenboek") clip = horde2audio[5];
        //Horde3
        if (sound == "accepteren") clip = horde3audio[0];
        if (sound == "benzine") clip = horde3audio[1];
        if (sound == "kersenpit") clip = horde3audio[2];
        if (sound == "kettinkje") clip = horde3audio[3];
        if (sound == "merkwaardig") clip = horde3audio[4];
        if (sound == "redactie") clip = horde3audio[5];
        if (sound == "tandarts") clip = horde3audio[6];
        if (sound == "thermometer") clip = horde3audio[7];

        //EndBoss
        if (sound == "juwelier") clip = endBoss[0];
        if (sound == "lekkage") clip = endBoss[1];
        if (sound == "vermoedelijk") clip = endBoss[2];
        if (sound == "veroorloven") clip = endBoss[3];
        if (sound == "waterpeil") clip = endBoss[4];
        return clip;
    }
}
