using UnityEngine;

public enum EnemyType {
    BAT,
    SKULL,
    GOLEM
};

public class EnemyTypeContainer : MonoBehaviour
{
    [SerializeField] public EnemyType enemyType;
}
