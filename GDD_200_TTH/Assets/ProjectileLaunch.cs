using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab; //drag prefab to this variable in editor
    private GameObject spawnedProjectile;
    private Rigidbody2D projectilePhysics;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.B))
        {
            spawnedProjectile = Instantiate(projectilePrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);

            //get physics of spawned projectile
            projectilePhysics = spawnedProjectile.GetComponent<Rigidbody2D>();

            //add force
            projectilePhysics.AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
        }
    }
}
