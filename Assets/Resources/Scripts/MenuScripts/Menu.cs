using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    private NpcLookInteractions choosedNpcLookInteraction;
    
    DialogManager dialogManager;
    AudioManager audioManager;
    Log logger;

    public void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        audioManager = FindObjectOfType<AudioManager>();
        logger = FindObjectOfType<Log>();
    }

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
        logger.logPressedButton(choosedNpcLookInteraction.ToString());
        FindObjectOfType<DialogManager>().StartDialog();
    }

    public NpcLookInteractions GetNpcLookInteractions()
    {
        return choosedNpcLookInteraction;
    }

    public void resetDialog()
    {
        logger.logPressedButton("Reset");
        dialogManager.Stop();
        audioManager.Stop();
    }
}
