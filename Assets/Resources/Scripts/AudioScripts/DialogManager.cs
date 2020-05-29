using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    bool playing;
    Queue<String> soundQueue;
    Queue<int> npcQueue;
    public GameObject[] from;
    public AudioManager audioManager;
    int currentNpc;

    public void Start()
    {
        soundQueue = new Queue<String>();
        npcQueue = new Queue<int>();
        playing = false;
    }

    public void StartDialog()
    {
        //TODO interrompre dialogue en cours
        if (playing) return;

        ClearQueues();
        Enqueue("1", 0);
        Enqueue("2", 1);
        Enqueue("3", 0);
        Enqueue("4", 1);
        Enqueue("5", 0);
        Enqueue("6", 1);
        Enqueue("7", 0);
        Enqueue("8", 1);
        Enqueue("9", 0);
        Enqueue("10", 1);
        Enqueue("11", 0);
        Enqueue("12", 1);
        Enqueue("13", 0);
        Enqueue("14", 1);
        Enqueue("15", 0);
        Enqueue("16", 1);

        playing = true;
        PlayNext();
    }

    private void ClearQueues()
    {
        soundQueue.Clear();
        npcQueue.Clear();
    }

    private void Enqueue(String sound, int npc)
    {
        soundQueue.Enqueue(sound);
        npcQueue.Enqueue(npc);
    }

    private void PlayNext()
    {
        currentNpc = npcQueue.Dequeue();
        from[currentNpc].GetComponentInChildren<Animator>().SetBool("talking", true);
        float time = audioManager.PlayFrom(soundQueue.Dequeue(), from[currentNpc]);
        StartCoroutine(WaitForNext(time));
    }

    IEnumerator WaitForNext(float time)
    {
        yield return new WaitForSeconds(time);
        if (playing)
        {
            from[currentNpc].GetComponentInChildren<Animator>().SetBool("talking", false);
            if (soundQueue.Count > 0)
            {
                PlayNext();

            } else playing = false;
        }
    }

    public void Stop()
    {
        ClearQueues();
        audioManager.Stop();
    }
}
