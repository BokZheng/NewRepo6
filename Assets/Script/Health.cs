using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HitEvent(GameObject source);
    public HitEvent OnHit;

    public delegate void ResetEvent();
    public ResetEvent OnHitReset;
    public cooldown iframe;
    
    private float MaxHealth = 10f;
    private float _currenthealth;
    float damaage = 1;
    private bool _canDamage = true;
    public float currenthealth
    {
        get { return _currenthealth; }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        ResetHealthToMax();
    }
    private void Update()
    {
        ResetIframe();
    }
    void ResetIframe()
    {
        if(_canDamage)
        {
            return;
        }
        if(iframe.isoncooldown && _canDamage == false)
        {

        }
    }

    // Update is called once per frame

    void Damage()
    {
        if (!_canDamage)
        {
            return;
        }

        _currenthealth -= damaage;

        if (_currenthealth <= 0 )
        {
            _currenthealth = 0;
            Die();
        }
    }

    public void Die()
    {

    }
    void ResetHealthToMax()
    {

    }
}
