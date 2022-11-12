using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Gun : Weapon
{
    public Transform barrel;
    public GameObject bullet;
    public float shootForce = 30f;

    private Animator anim;
    private bool hasMag = true;

    public Transform magHolder;
    public GameObject magPrefab;
    public float damage = 100f;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hasMag)
            Shoot();


        Reload();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            

            anim.SetTrigger("shooting");

            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            GameObject projectile = Instantiate(bullet, barrel.position, Quaternion.identity);
            projectile.GetComponent<Bullet>().damage = this.damage;

            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            } else
            {
                targetPoint = ray.GetPoint(75);
            }

            Vector3 directionWithoutSpread = targetPoint - barrel.transform.position;

            
            projectile.transform.forward = directionWithoutSpread.normalized;

            projectile.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);

            CameraShaker.Instance.ShakeOnce(2f, 1f, .1f, .5f);
        }
    }

    private void Reload ()
    {
        if (Input.GetKeyDown("r")) 
        {
            

            Debug.Log("PRESS");
            if (hasMag)
            {
                GameObject mag = magHolder.GetChild(0).gameObject;
                mag.GetComponent<Rigidbody>().isKinematic = false;
                mag.GetComponent<Rigidbody>().useGravity = true;
                mag.transform.parent = null;
                hasMag = false;
                return;
            }

            if (!hasMag)
            {
                GameObject newMag = Instantiate(magPrefab, magHolder);
                newMag.transform.parent = magHolder;
                newMag.GetComponent<Rigidbody>().isKinematic = true;
                newMag.GetComponent<Rigidbody>().useGravity = false;
                hasMag =true;
                return;
            }
        }
    }
}
