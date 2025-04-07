using UnityEngine;


//checked of dat een spel wordt gespeeld op telefoon of desktop en zet bepaalde scripts aan het uit afhankelijk daarvan
public class PhoneCheck : MonoBehaviour
{
    void Awake()
    {
        // Controleer of het een PC/Mac/Linux build is
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.OSXPlayer ||
            Application.platform == RuntimePlatform.LinuxPlayer ||
            Application.isEditor) // Ook uitschakelen in de Unity Editor
        {
            PlayerPrefs.SetString("phoneCheck", "PC");
            //GetComponent<PhoneControls>().enabled = false;
            //GetComponent<PhoneShoot>().enabled = false;
        }
        else
        {
            PlayerPrefs.SetString("phoneCheck", "Phone");
            //GetComponent<Speler>().enabled = false;
            //GetComponent<Shooting>().enabled = false;
        }

        Debug.Log(PlayerPrefs.GetString("phoneCheck"));
    }
}
