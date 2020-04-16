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
        Enqueue("dialogue_test_1", 0);
        Enqueue("dialogue_test_2", 1);
        Enqueue("dialogue_test_3", 0);
        Enqueue("dialogue_test_4", 1);

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
        float time = audioManager.PlayFrom(soundQueue.Dequeue(), from[npcQueue.Dequeue()]);
        StartCoroutine(WaitForNext(time));
    }

    IEnumerator WaitForNext(float time)
    {
        yield return new WaitForSeconds(time);
        if (playing)
        {
            if (soundQueue.Count > 0) PlayNext();
            else playing = false;
        }
    }
}
