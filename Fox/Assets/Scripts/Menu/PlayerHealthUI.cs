using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{
    public static float PlayerMaxHealth = 20;
    public static float PlayerCurrHealth = 20;
    public Text HealthText;
    private Image HealthLengthUI;
    // Start is called before the first frame update
    void Start()
    {
        HealthLengthUI = gameObject.GetComponent<Image>();
        PlayerCurrHealth = PlayerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthLengthUI.fillAmount = PlayerCurrHealth / PlayerMaxHealth;
        HealthText.text = (PlayerCurrHealth + "/" + PlayerMaxHealth);
    }

}
