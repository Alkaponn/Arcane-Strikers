using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonClick;
    [SerializeField] AudioClip dropSound;
    [SerializeField] AudioClip defaultSound;
    [SerializeField] AudioClip waterSound;
    [SerializeField] AudioClip fireSound;
    [SerializeField] AudioClip lightningSound;
    [SerializeField] AudioClip arcaneSound;
    [SerializeField] AudioClip enemySound;

    public void PlayButtonClick() {
        audioSource.PlayOneShot(buttonClick);
    }

    public void PlayDropSound(GameObject staffPrefab) {
        audioSource.PlayOneShot(dropSound, 0.1f);
    }

    public void PlayDefaultSound() {
        audioSource.PlayOneShot(defaultSound, 0.1f);
    }

    public void PlayWaterSound() {
        audioSource.PlayOneShot(waterSound, 0.1f);
    }

    public void PlayFireSound() {
        audioSource.PlayOneShot(fireSound, 0.1f);
    }

    public void PlayLightningSound() {
        audioSource.PlayOneShot(lightningSound, 0.1f);
    }

    public void PlayArcaneSound() {
        audioSource.PlayOneShot(arcaneSound, 0.1f);
    }

    public void PlayEnemySound() {
        audioSource.PlayOneShot(enemySound, 0.1f);
    }
}
