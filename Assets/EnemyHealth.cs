using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHP = 100;
    public float currentHealth;
    public Vector2 Position;
    private Vector2 colliderWorldPos;
    
    private SpriteRenderer SpriteRen;
    private CapsuleCollider2D BCollider;
    private Rigidbody2D Rbody;

    public event Action<float,float> OnHealthChange;
     


    public void TakeDamage(Weapons weapon, Vector2 positionOfAttack)
    {
        currentHealth -= weapon.damage;

        if (positionOfAttack.x < BCollider.transform.position.x){Rbody.AddForceX(100f);}
        if (positionOfAttack.x > BCollider.transform.position.x){Rbody.AddForceX(-100f);}

        if(OnHealthChange != null)
        {
            OnHealthChange.Invoke(currentHealth, MaxHP);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = MaxHP;
        SpriteRen = GetComponent<SpriteRenderer>();
        Rbody = GetComponent<Rigidbody2D>();
        BCollider = GetComponent<CapsuleCollider2D>();
        Debug.Log(BCollider.transform.position.x);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth <= 0){Destroy(gameObject);}  
    }
}
