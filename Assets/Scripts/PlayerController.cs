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

        public KeyCode KickKey;
        public KeyCode SnareKey;

        private void Update()
        {
            if (Input.GetKeyDown(KickKey))
            {
                Kick.PlayOneShot(Kick.clip);
            }

            if (Input.GetKeyDown(SnareKey))
            {
                Snare.PlayOneShot(Snare.clip);
            }
        }
    }
}
