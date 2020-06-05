﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    private NpcLookInteractions choosedNpcLookInteraction;
    
    public DialogManager dialogManager;
    public AudioManager audioManager;
    public Log logger;

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
