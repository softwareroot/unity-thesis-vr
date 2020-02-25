using UnityEngine;

public class QuestionLevel : MonoBehaviour
{

    [SerializeField] public GameObject questionText;
    [SerializeField] public GameObject removeText0, removeText1, removeText2;
    public static bool isStandingOnQuestionmark;
    
    void Start()
    {
        isStandingOnQuestionmark = false;
        questionText.SetActive(false);
    }

    void Update()
    {
        if (isStandingOnQuestionmark)
            questionText.SetActive(true);
        else
            questionText.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isStandingOnQuestionmark = true;
            GetComponent<MeshRenderer>().enabled = false;

            if (removeText0 != null)
            {
                removeText0.SetActive(false);
            }
            
            if (removeText1 != null)
            {
                removeText1.SetActive(false);
            }
            
            if (removeText2 != null)
            {
                removeText2.SetActive(false);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isStandingOnQuestionmark = false;
        GetComponent<MeshRenderer>().enabled = true;
        
        if (removeText0 != null)
        {
            removeText0.SetActive(true);
        }
            
        if (removeText1 != null)
        {
            removeText1.SetActive(true);
        }
            
        if (removeText2 != null)
        {
            removeText2.SetActive(true);
        }
    }
}
