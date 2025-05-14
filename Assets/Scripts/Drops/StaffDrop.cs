using UnityEngine;
using System;

public class StaffDrop : MonoBehaviour
{
    [SerializeField] GameObject staffPrefab;

    public event Action<GameObject> OnDropReceive;

    private DropManager dropManager;
    private AudioManager audioManager;

    void Start()
    {
        dropManager = GameObject.FindGameObjectWithTag("DropManager").GetComponent<DropManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        OnDropReceive += dropManager.OnDropReceiveAction;
        OnDropReceive += audioManager.PlayDropSound;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObject = collision.gameObject;

        if (hitObject.CompareTag("Player")) {
            OnDropReceive?.Invoke(staffPrefab);
            Destroy(gameObject);
        }
    }
}
