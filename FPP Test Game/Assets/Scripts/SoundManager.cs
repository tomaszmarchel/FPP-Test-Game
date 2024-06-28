using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClipRefsSO audioClipRefsSO;

    private void Start()
    {
        Player.Instance.OnRifleShootEvent += Player_OnRifleShootEvent;
        GameInput.Instance.OnTakeMeasurement += GameInput_OnTakeMeasurement;
        GameInput.Instance.OnIncreaseRing += GameInput_OnIncreaseRing;
        GameInput.Instance.OnDecreaseRing += GameInput_OnDecreaseRing;
    }

    private void GameInput_OnDecreaseRing(object sender, System.EventArgs e)
    {
        PlayClickSound();
    }

    private void GameInput_OnIncreaseRing(object sender, System.EventArgs e)
    {
        PlayClickSound();
    }

    private void PlayClickSound()
    {
        PlaySound(audioClipRefsSO.clickAudioClip, Camera.main.transform.position);
    }

    private void GameInput_OnTakeMeasurement(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.scanAudioClip, Camera.main.transform.position);
    }

    private void Player_OnRifleShootEvent(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.shootAudioClip, Camera.main.transform.position);
    }

    public void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }


}
