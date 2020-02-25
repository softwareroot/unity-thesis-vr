using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{

    [SerializeField] public GameObject textGun, textHP;

    void Update()
    {
        if (Scope.isScoped)
        {
            textGun.SetActive(false);
            textHP.SetActive(false);
        } else
        {
            if (!QuestionLevel.isStandingOnQuestionmark) {
                textGun.SetActive(true);
                textHP.SetActive(true);
            }
        }
    }
}
