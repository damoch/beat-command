using UnityEngine;

namespace Assets.Scripts
{
    public class RhythmController : MonoBehaviour
    {
        public int BPM;
        public AudioClip HatClip;
        public AudioSource HiHat;
        private float _breakTime;
        private float _elapsed;

        private void Start()
        {
            _elapsed = 0;
            _breakTime = (float)60 / BPM;
        }

        private void Update()
        {
            _elapsed += Time.deltaTime;
            if(_elapsed < _breakTime)
            {
                return;
            }
            HiHat.PlayOneShot(HatClip);
            _elapsed = 0;
        }
    }
}
