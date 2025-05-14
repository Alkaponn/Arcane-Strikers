using UnityEngine;
using System;

public class StaffDrop : MonoBehaviour
{
    [SerializeField] GameObject staffPrefab;

    public event Action<GameObject> OnDropReceive;

    private DropManager dropManager;

    void Start()
    {
        dropManager = GameObject.FindGameObjectWithTag("DropManager").GetComponent<DropManager>();

        OnDropReceive += dropManager.OnDropReceiveAction;
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
