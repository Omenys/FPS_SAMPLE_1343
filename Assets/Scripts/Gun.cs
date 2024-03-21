using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    // references
    [SerializeField] Transform gunBarrelEnd;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Animator anim;

    // events
    [SerializeField] UnityEvent<int, int> AmmoUpdate;
    [SerializeField] UnityEvent Interact;

    // stats
    [SerializeField] int maxAmmo;
    [SerializeField] float timeBetweenShots = 0.1f;

    // private variables
    int ammo;
    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        AmmoUpdate?.Invoke(maxAmmo, ammo);
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
    }

    public bool AttemptFire()
    {
        if (ammo <= 0)
        {
            return false;
        }

        if (elapsed < timeBetweenShots)
        {
            return false;
        }


        Debug.Log("Bang");
        Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        anim.SetTrigger("shoot");
        timeBetweenShots = 0;
        ammo -= 1;


        AmmoUpdate?.Invoke(maxAmmo, ammo);

        Debug.Log(ammo);


        return true;
    }

    public void AddAmmo(int amount)
    {
        /*if (ammo + amount > maxAmmo)
        {
            ammo = maxAmmo;
        }
        else
        {
            ammo += amount;
        }*/

        ammo = maxAmmo;
        AmmoUpdate?.Invoke(maxAmmo, ammo);

        //Debug.Log("Gun event works!");

    }

}


