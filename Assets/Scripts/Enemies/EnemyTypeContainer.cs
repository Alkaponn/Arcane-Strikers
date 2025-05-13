using UnityEngine;

public enum EnemyType {
    BAT,
    BATBOSS,
    SKULL,
    SKULLBOSS,
    GOLEM,
    GOLEMBOSS
};

public class EnemyTypeContainer : MonoBehaviour
{
    [SerializeField] public EnemyType enemyType;
}
