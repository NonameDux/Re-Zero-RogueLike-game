using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] public Slider healthbar;

    [SerializeField] public EnemyHealth Enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy = GetComponent<EnemyHealth>();
    }

    void OnEnable()
    {
        Enemy.OnHealthChange += RefreshBar;
    }
    void OnDisable()
    {
        Enemy.OnHealthChange -= RefreshBar;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshBar(float hp, float maxhp)
    {
        healthbar.value = (hp/(maxhp/100))/100;
    }
}
