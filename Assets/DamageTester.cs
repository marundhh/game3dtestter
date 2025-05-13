using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public AttributesManager player_atm;
    public AttributesManager enemy_atm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            player_atm.DealDamage(enemy_atm.gameObject);
       
    }

    void Start()
    {
        
    }
    


    
}
