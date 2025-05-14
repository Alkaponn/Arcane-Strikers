using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropManager : MonoBehaviour
{
    public enum StaffType {
        WATER,
        FIRE,
        LIGHTNING,
        ARCANE,
        DEFAULT
    }

    [SerializeField] GameObject waterStaffDropPrefab;
    [SerializeField] GameObject fireStaffDropPrefab;
    [SerializeField] GameObject lightningStaffDropPrefab;
    [SerializeField] GameObject arcaneStaffDropPrefab;
    [SerializeField] float probabilityPerEnemy;
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

    public void Drop(GameObject enemy) {
        float rand = Random.Range(0f, 1f);

        if (rand <= probabilityPerEnemy) {
            int maxStaffTypeEnum = (int) StaffType.DEFAULT;
            int selectedInt = Random.Range(0, maxStaffTypeEnum);
            StaffType staffType = (StaffType) selectedInt;
            GameObject selectedPrefab = waterStaffDropPrefab;

            switch (staffType) {
                case StaffType.WATER:
                    selectedPrefab = waterStaffDropPrefab;
                    break;
                case StaffType.FIRE:
                    selectedPrefab = fireStaffDropPrefab;
                    break;
                case StaffType.LIGHTNING:
                    selectedPrefab = lightningStaffDropPrefab;
                    break;
                case StaffType.ARCANE:
                    selectedPrefab = arcaneStaffDropPrefab;
                    break;
                default:
                    break;
            }

            Instantiate(selectedPrefab, enemy.transform.position, Quaternion.identity);
        }
    }
}
