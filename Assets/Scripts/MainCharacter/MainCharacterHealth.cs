using System;
using UnityEngine;

public class MainCharacterHealth : Health
{
    public event Action OnPlayerDeath;

    protected override void ApplyAfterDeathEffect()
    {
        OnPlayerDeath?.Invoke();
    }
}
