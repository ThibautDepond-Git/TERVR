using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private const String path = "Assets/Resources/Dialog/";
    private const String ext = ".txt";

    bool playing;
    Queue<String> soundQueue;
    Queue<String> npcQueue;
 
    private List<GameObject> from;
    private GameObject currentNpc;

    AudioManager audioManager;
    Log logger;
    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        logger = FindObjectOfType<Log>();

        soundQueue = new Queue<String>();
        npcQueue = new Queue<String>();
        playing = false;
        from = GameObject.FindGameObjectsWithTag("NPC").ToList();
    }

    public void StartDialog()
    {
        if (playing) return;
        LoadScenario("dialog");
        playing = true;
        PlayNext();
        logger.log(" - [DIALOGMANAGER] - dialog start");
    }

    public void LoadScenario(String name)
    {
        ClearQueues();
        StreamReader reader = new StreamReader(path + name + ext, false);
        while (!reader.EndOfStream)
        {
            String l = reader.ReadLine();
            if (l != null)
            {
                String[] line = l.Split(',');
                Enqueue(line[0], line[1]);
            }
        }
    }

    private void ClearQueues()
    {
        soundQueue.Clear();
        npcQueue.Clear();
    }

    private void Enqueue(String sound, String npc)
    {
        soundQueue.Enqueue(sound);
        npcQueue.Enqueue(npc);
    }

    private void PlayNext()
    {
        String npcName = npcQueue.Dequeue();
        currentNpc = from.Find(npc => npc.name == npcName);
        float time = audioManager.PlayFrom(soundQueue.Dequeue(), currentNpc);
        StartCoroutine(WaitForNext(time));
    }

    IEnumerator WaitForNext(float time)
    {
        yield return new WaitForSeconds(time);
        if (playing)
        {
            if (soundQueue.Count > 0)
            {
                PlayNext();
            }
            else
            {
                playing = false;
                logger.log(" - [DIALOGMANAGER] - dialog end");
            }
        }
    }

    public void Stop()
    {
        logger.log(" - [DIALOGMANAGER] - dialog has been interrupt");
        StopAllCoroutines();
        playing = false;
        ClearQueues();
    }

    public GameObject GetCurrentNpc()
    {
        return currentNpc;
    }

    public bool GetPlaying()
    {
        return playing;
    }
}
