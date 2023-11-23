using UnityEngine;

namespace Support
{
    public struct Song
    {
        public AudioClip audioClip;
        public int bpm;

        public Song(AudioClip audioClip, int bpm)
        {
            this.audioClip = audioClip;
            this.bpm = bpm;
        }
    }
}