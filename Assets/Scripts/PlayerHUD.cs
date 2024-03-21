using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text currentAmmoText;
    [SerializeField] TMP_Text maxAmmoText;

    FPSController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSController>();

    }


    public void UpdateAmmo(int maxAmmo, int currentAmmo)
    {
        maxAmmoText.text = maxAmmo.ToString();
        currentAmmoText.text = currentAmmo.ToString();

    }
}
