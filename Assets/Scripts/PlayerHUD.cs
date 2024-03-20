using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI currentAmmoText;
    [SerializeField] TMP_Text maxAmmoText;

    FPSController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSController>();

    }


    public void UpdateAmmo(Gun gun)
    {
        currentAmmoText.text = gun.ammo.ToString();
        maxAmmoText.text = gun.maxAmmo.ToString();

    }
}
