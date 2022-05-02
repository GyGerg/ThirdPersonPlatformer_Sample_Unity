using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/New Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int maxAmmo;
    public int MaxAmmo => maxAmmo;
    
    [SerializeField] private float fireRate;
    public float FireRate => fireRate;
    public void Fire(GameObject from, Vector3 to)
    {
        var proj = Instantiate(projectilePrefab);
        var rb = proj.GetComponent<Rigidbody>() ?? proj.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce((to - from.transform.position).normalized * 5f, ForceMode.Impulse);
    }
    
    
}
