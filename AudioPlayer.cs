using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Collect Coin")]
    [SerializeField] AudioClip coinClip;
    [SerializeField] [Range(0f, 1f)] float coinVolume = 1f;
    [Header("Swipe")]
    [SerializeField] AudioClip swipeClip;
    [SerializeField] [Range(0f, 1f)] float swipeVolume = 1f;

    [Header("Bounc")]
    [SerializeField] AudioClip bounceClip;
    [SerializeField] [Range(0f, 1f)] float bounceVolume = 1f;

    public void PlayCoinClip(){
        AudioSource.PlayClipAtPoint(coinClip, Camera.main.transform.position, coinVolume);
    }
    public void PlaySwipeClip(){
        AudioSource.PlayClipAtPoint(swipeClip, Camera.main.transform.position, swipeVolume);
    }
    public void PlayBounceClip(){
        AudioSource.PlayClipAtPoint(bounceClip, Camera.main.transform.position, bounceVolume);
    }
}
