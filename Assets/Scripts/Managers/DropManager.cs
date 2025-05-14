using UnityEngine;
using System.Collections;

public class DropManager : MonoBehaviour
{
    [SerializeField] GameObject defaultStaffPrefab;
    [SerializeField] float staffDuration;

    private GameObject player;
    private int numActiveDrops = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnDropReceiveAction(GameObject staffPrefab) {
        StartCoroutine(GiveDropForDuration(staffPrefab));
    }

    IEnumerator GiveDropForDuration(GameObject staffPrefab) {
        GiveStaffToPlayer(staffPrefab);
        numActiveDrops++;
        yield return new WaitForSeconds(staffDuration);

        if (numActiveDrops == 1) {
            GiveStaffToPlayer(defaultStaffPrefab);
        }

        numActiveDrops--;
    }

    public void GiveStaffToPlayer(GameObject staffPrefab) {
        GameObject defaultStaff = GameObject.FindGameObjectWithTag("Staff");
        Vector2 staffPosition = (Vector2) defaultStaff.transform.position;
        Destroy(defaultStaff);
        Instantiate(staffPrefab, staffPosition, Quaternion.identity, player.transform);
    }
}
