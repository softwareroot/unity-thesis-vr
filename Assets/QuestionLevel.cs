using UnityEngine;

public class QuestionLevel : MonoBehaviour
{

    [SerializeField] public GameObject UI_element_weapons, UI_element_htp,
        UI_element_sniper_lock, UI_element_launcher_lock;
    [SerializeField] public GameObject gameplayCanvas;
    [SerializeField] public GameObject weaponHolder;
    
    private static bool isStandingOnQuestionmarkWeapons, isStandingOnQuestionmarkHTP;
    private static bool isStandingOnQuestionmarkLockSniper, isStandingOnQuestionmarkLockLauncher;
    
    void Start()
    {
        isStandingOnQuestionmarkWeapons = false;
        isStandingOnQuestionmarkHTP = false;
        isStandingOnQuestionmarkLockSniper = false;
        isStandingOnQuestionmarkLockLauncher = false;
        UI_element_weapons.SetActive(false);
        UI_element_htp.SetActive(false);
        UI_element_sniper_lock.SetActive(false);
        UI_element_launcher_lock.SetActive(false);
        gameplayCanvas.SetActive(true);
    }

    void Update()
    {
        if (isStandingOnQuestionmarkWeapons) {
            UI_element_weapons.SetActive(true);
            UI_element_htp.SetActive(false);
            
            if (UI_element_launcher_lock != null)
            {
                UI_element_launcher_lock.SetActive(false);
            }
            
            if (UI_element_sniper_lock != null)
            {
                UI_element_sniper_lock.SetActive(false);
            }
            
            weaponHolder.SetActive(false);
            gameplayCanvas.SetActive(false);
        } else if (isStandingOnQuestionmarkHTP)
        {
            UI_element_weapons.SetActive(false);
            UI_element_htp.SetActive(true);
            
            if (UI_element_launcher_lock != null)
            {
                UI_element_launcher_lock.SetActive(false);
            }
            
            if (UI_element_sniper_lock != null)
            {
                UI_element_sniper_lock.SetActive(false);
            }
            
            weaponHolder.SetActive(false);
            gameplayCanvas.SetActive(false);
        } else if (isStandingOnQuestionmarkLockSniper)
        {
            UI_element_weapons.SetActive(false);
            UI_element_htp.SetActive(false);
            
            if (UI_element_launcher_lock != null)
            {
                UI_element_launcher_lock.SetActive(false);
            }
            
            if (UI_element_sniper_lock != null)
            {
                UI_element_sniper_lock.SetActive(true);
            }
            
            weaponHolder.SetActive(true);
            gameplayCanvas.SetActive(false);
        } else if (isStandingOnQuestionmarkLockLauncher)
        {
            UI_element_weapons.SetActive(false);
            UI_element_htp.SetActive(false);
            if (UI_element_launcher_lock != null)
            {
                UI_element_launcher_lock.SetActive(true);
            }
            
            if (UI_element_sniper_lock != null)
            {
                UI_element_sniper_lock.SetActive(false);
            }
            weaponHolder.SetActive(true);
            gameplayCanvas.SetActive(false);
        } else
        {
            UI_element_weapons.SetActive(false);
            UI_element_htp.SetActive(false);
            
            if (UI_element_launcher_lock != null)
            {
                UI_element_launcher_lock.SetActive(false);
            }
            
            if (UI_element_sniper_lock != null)
            {
                UI_element_sniper_lock.SetActive(false);
            }

            
            gameplayCanvas.SetActive(true);
            weaponHolder.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "info_weapons")
            {
                isStandingOnQuestionmarkWeapons = true;
                isStandingOnQuestionmarkHTP     = false;
                isStandingOnQuestionmarkLockSniper = false;
                isStandingOnQuestionmarkLockLauncher = false;
            } else if (gameObject.tag == "info_htp")
            {
                isStandingOnQuestionmarkWeapons      = false;
                isStandingOnQuestionmarkHTP          = true;
                isStandingOnQuestionmarkLockSniper   = false;
                isStandingOnQuestionmarkLockLauncher = false;
            } else if (gameObject.tag == "info_sniper_lock")
            {
                isStandingOnQuestionmarkWeapons      = false;
                isStandingOnQuestionmarkHTP          = false;
                isStandingOnQuestionmarkLockSniper   = true;
                isStandingOnQuestionmarkLockLauncher = false;
            } else if (gameObject.tag == "info_launcher_lock")
            {
                isStandingOnQuestionmarkWeapons      = false;
                isStandingOnQuestionmarkHTP          = false;
                isStandingOnQuestionmarkLockSniper   = false;
                isStandingOnQuestionmarkLockLauncher = true;
            } else
            {
                isStandingOnQuestionmarkWeapons      = false;
                isStandingOnQuestionmarkHTP          = false;
                isStandingOnQuestionmarkLockSniper   = false;
                isStandingOnQuestionmarkLockLauncher = false;
            }
            
            GetComponent<MeshRenderer>().enabled = false;
            gameplayCanvas.SetActive(false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isStandingOnQuestionmarkWeapons = false;
        isStandingOnQuestionmarkHTP = false;
        isStandingOnQuestionmarkLockSniper   = false;
        isStandingOnQuestionmarkLockLauncher = false;
        GetComponent<MeshRenderer>().enabled = true;
        gameplayCanvas.SetActive(true);
    }
}
