using UnityEngine;
using Unity.Cinemachine;
using System;

public class Effects : MonoBehaviour
{
    private CinemachineImpulseSource cameraIS;
    [SerializeField] public GameObject Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraIS = GetComponent<CinemachineImpulseSource>();

        
    }
    void OnEnable()
    {
        Attack.OnAttack += Shake;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Shake(Collider2D enemyCollider, float damage)
    {
        cameraIS.GenerateImpulse();
    }
}
