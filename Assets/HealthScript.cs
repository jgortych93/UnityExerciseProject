using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{   
    private uint _health;

    public uint Health
    {
        get => _health;
        set {
            _health = value;
            HandleHealthChange();
        }
    }

    HealthScript()
    {
        this._health = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void HandleHealthChange()
    {
        if (this._health >= 3)
        {

        }
    }
}
