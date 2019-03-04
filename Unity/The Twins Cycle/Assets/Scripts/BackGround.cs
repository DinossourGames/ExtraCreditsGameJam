using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround  : MonoBehaviour
{
    public AudioClip[] musics;
    private AudioSource source { get { return GetComponent<AudioSource>();}}
    private static GameObject musicInstancer;

    public bool ativo = true;

    [Range(0.1f, 1.0f)]
    public float volume = 0.1f;
    
    void Awake(){
        gameObject.AddComponent<AudioSource>();
        DontDestroyOnLoad (this);
            
        if (musicInstancer == null) {
            musicInstancer = transform.gameObject;
        } else {
            Destroy(gameObject);
        }

        source.volume = volume;
        source.clip = musics[Random.Range(0,musics.Length)] as AudioClip;

    }

    void Start(){
        source.Play();
        
    }

    void Update () {
        if(!source.isPlaying && ativo){
            playRandomMusic();
            ativo = true;
            }
        else if(source.isPlaying && !ativo){
            source.Stop();
            PlayerPrefs.SetInt("Music",0);
            ativo = false;            
            }

    }

    void playRandomMusic(){
        source.clip = musics[Random.Range(0,musics.Length)] as AudioClip;
        source.Play();
        ativo = true;

    }
}
