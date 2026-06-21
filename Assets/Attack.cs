using UnityEngine;
using System;



public class Attack : MonoBehaviour
{
    private BoxCollider2D AttackBox; 
    public Weapons currentWeapon;
    public PlayerManager PM;
    public Vector2 posAbsolute;
    public static event Action<Collider2D,float> OnAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        AttackBox = GetComponent<BoxCollider2D>(); 
        PM = GetComponentInParent<PlayerManager>();     
    }

    void OnEnable()
    {
        AttackBox.size = currentWeapon.hitbox;
        if (!PM.isLeft){AttackBox.offset = new Vector2(AttackBox.size.x/2,AttackBox.offset.y);}
        else{AttackBox.offset = new Vector2(AttackBox.size.x*(-0.5f),AttackBox.offset.y);}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth TriggeredObject = collision.GetComponent<EnemyHealth>();
        Debug.Log($"Хитбокс коснулся врага! Переменная currentWeapon равна: {currentWeapon}");
        if (TriggeredObject.CompareTag("Enemy"))
        {
            posAbsolute = AttackBox.transform.position;
            TriggeredObject.TakeDamage(currentWeapon, posAbsolute);
            OnAttack?.Invoke(collision,currentWeapon.damage);

        }
        
    }
}
