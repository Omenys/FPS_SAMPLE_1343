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
    [SerializeField] UnityEvent<float, float> OnFire;
    [SerializeField] UnityEvent Emit;

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

        // Update ammo
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

        // Update ammo
        AmmoUpdate?.Invoke(maxAmmo, ammo);

        // Particle system for muzzle flash
        Emit?.Invoke();

        // Shake camera
        OnFire?.Invoke(0.1f, 2.5f);


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

        // Update ammo
        AmmoUpdate?.Invoke(maxAmmo, ammo);



    }

}


