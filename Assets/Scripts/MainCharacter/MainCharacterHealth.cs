using UnityEngine;

public class MainCharacterHealth : Health
{
    protected override void ApplyAfterDeathEffect()
    {
        print("You Died!");
    }
}
