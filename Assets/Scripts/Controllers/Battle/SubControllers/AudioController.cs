using Controllers.Utility;
using Support;
using UnityEngine;
using Random = System.Random;
using System.Collections;

namespace Controllers.Battle.SubControllers
{
    public class AudioController: MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip[] songs;
        [SerializeField] private int[] bpm;
        private Song pickedSong;

        private void Start()
        {
            StartCoroutine(StartBattle());
        }

        private IEnumerator StartBattle()
        {
            yield return new WaitForSeconds(1.5f);
            Random random = new Random();
            int index = random.Next(songs.Length);
            pickedSong = new Song(songs[index], bpm[index]);
            GlobalEventController.SendOnBattleStarted(pickedSong);
            source.clip = pickedSong.audioClip;
            source.loop = true;
            source.Play();
        }
    }
}