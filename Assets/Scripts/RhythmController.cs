using UnityEngine;

namespace Assets.Scripts
{
    public class RhythmController : MonoBehaviour
    {
        public int BPM;
        public AudioClip HatClip;
        public AudioSource HiHat;
        private float _breakTime;
        private float _onBeatTime;
        private float _elapsed;
        private float _elapsedOnBeat;
        public bool OnBeat;
        private int _beatNumber;
        public RhythmDisplay RhythmDisplay;
        public MissileCreator MissileCreator;

        private void Start()
        {
            OnBeat = false;
            _elapsed = 0;
            _elapsedOnBeat = 0;
            _breakTime = (float)60 / BPM;
            _onBeatTime = _breakTime * .75f;
            _beatNumber = 0;
        }

        private void Update()
        {
            if (OnBeat)
            {
                _elapsedOnBeat -= Time.deltaTime;
                if (_elapsedOnBeat < 0)
                {
                    OnBeat = false;
                    HiHat.Stop();
                    RhythmDisplay.gameObject.SetActive(false);
                }
            }
            _elapsed += Time.deltaTime;
            if(_elapsed < _breakTime)
            {
                return;
            }
            MissileCreator.CreateMissile(++_beatNumber);
            HiHat.PlayOneShot(HatClip);
            _elapsed = 0;
            OnBeat = true;
            RhythmDisplay.gameObject.SetActive(true);
            _elapsedOnBeat = _onBeatTime;
        }
    }
}
