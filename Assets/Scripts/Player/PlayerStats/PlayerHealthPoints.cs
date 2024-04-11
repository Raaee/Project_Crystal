using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPoints : HealthPoints
{

    public override void Start() 
    {
      base.Start();  
    }

    [ProButton]
    public override void Die()
    {       
        OnHealthChange?.Invoke();
        OnDead?.Invoke();
    }
    public override void ResetHealth() 
    {
        base.ResetHealth();
    }

}
