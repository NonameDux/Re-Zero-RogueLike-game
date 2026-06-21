using UnityEngine;
using System.Collections;

public class EnemyAnimator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private EnemyHealth enemyHealth;
    private float lasthp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        enemyHealth = GetComponent<EnemyHealth>();

        lasthp = enemyHealth.MaxHP;
        enemyHealth.OnHealthChange += HandleHealthChange;
    }

    // Update is called once per frame
    void HandleHealthChange(float currentHealth, float MaxHP)
    {
        if (currentHealth < lasthp)
        {
            StartCoroutine(FlashColorCoroutine(Color.red));
        }
        if (currentHealth > lasthp)
        {
            StartCoroutine(FlashColorCoroutine(Color.green));
        }

        lasthp = currentHealth;
    }

    IEnumerator FlashColorCoroutine(Color flashColor)
    {
        spriteRenderer.color = flashColor; // Красим спрайт в нужный цвет
        
        yield return new WaitForSeconds(0.15f); // Ждем долю секунды (1 секунда — это слишком долго для удара)
        
        spriteRenderer.color = Color.white; // Возвращаем обычный белый цвет спрайта
    }
}
