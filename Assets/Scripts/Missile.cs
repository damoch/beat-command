using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Missile : MonoBehaviour
    {
        public float MinSpeed;
        public float MaxSpeed;
        public MissileType MissileType;

        private float _speed;

        private void Update()
        {
            transform.Translate(Vector2.up * _speed);
        }

        public void SetSpeed(bool onBeat)
        {
            _speed = onBeat ? MaxSpeed : MinSpeed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var otherMissile = collision.gameObject.GetComponent<Missile>();

            if (otherMissile && otherMissile.MissileType == MissileType)
            {
                Destroy(otherMissile.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
