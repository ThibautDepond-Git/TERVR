using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenario : MonoBehaviour
{

    private NpcLookInteractions choosedNpcLookInteraction;
    public void StartDialog(int scNb)
    {
        switch (scNb)
        {
            case 1:
                {
                    choosedNpcLookInteraction = NpcLookInteractions.Always;
                    break;
                }
            case 2:
                {
                    choosedNpcLookInteraction = NpcLookInteractions.Never;
                    break;
                }
            case 3:
                {
                    choosedNpcLookInteraction = NpcLookInteractions.WhenNotLooked;
                    break;
                }
            case 4:
                {
                    choosedNpcLookInteraction = NpcLookInteractions.WhenLooked;
                    break;
                }
        }
        
        FindObjectOfType<DialogManager>().StartDialog();
    }

    public NpcLookInteractions GetNpcLookInteractions()
    {
        return choosedNpcLookInteraction;
    }
}
