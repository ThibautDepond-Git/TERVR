using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenario : MonoBehaviour
{

    public int scenarioId;
    // Start is called before the first frame update
    public void StartDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog();
    }
}
