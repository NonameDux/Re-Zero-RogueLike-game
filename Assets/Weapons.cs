using UnityEngine;

public enum WeaponRarity
{
    Common,    
    Rare,        
    Epic,       
    Legendary,  
    Mythic      
}

[CreateAssetMenu(fileName = "Weapons", menuName = "Items/Weapons")]
public class Weapons : ScriptableObject
{
    [Header("Visual & Info")]
    public string weaponName;
    public WeaponRarity rarity;
    public bool ranged;
    public Vector2 spriteSize;
    public Sprite icon;
    public Sprite sprite;

    [Header("Stats")]
    public float damage;
    public Vector2 hitbox;
    public float recoil;
    public float cooldown;

    [Header("Audio & Effects")]
    public AudioClip attackSound;     
    public GameObject hitEffectPrefab;
}
