using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public AudioSource Kick;
        public AudioSource Snare;
        public Transform KickSpawner;
        public Transform SnareSpawner;
        public GameObject KickMissile;
        public GameObject SnareMissile;
        public RhythmController RhythmController;

        public KeyCode KickKey;
        public KeyCode SnareKey;

        private void Update()
        {
            if (Input.GetKeyDown(KickKey))
            {
                FireKickMissile();
            }

            if (Input.GetKeyDown(SnareKey))
            {
                FireSnareMissile();
            }

            transform.localRotation = Quaternion.Euler(0f, 0f, AngleBetweenTwoPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition))+90);
        }

        private void FireSnareMissile()
        {
            var missile = Instantiate(SnareMissile, SnareSpawner.position, transform.rotation).GetComponent<Missile>();
            missile.SetSpeed(RhythmController.OnBeat);
            Snare.PlayOneShot(Snare.clip);
        }

        private void FireKickMissile()
        {
            var missile = Instantiate(KickMissile, KickSpawner.position, transform.rotation).GetComponent<Missile>();
            missile.SetSpeed(RhythmController.OnBeat);
            Kick.PlayOneShot(Kick.clip);
        }

        private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}
