using UnityEngine;

namespace Assets.Scripts
{
    public class MissileCreator : MonoBehaviour
    {
        public float MinX;
        public float MaxX;

        public GameObject SnareMissile;
        public GameObject KickMissile;

        public Transform PlayerPosition;

        public void CreateMissile(int beatNumber)
        {
            var rng = Random.Range(0, 100);

            if (rng < 50)
            {
                return;
            }
            var spanwPos = new Vector2(Random.Range(MinX, MaxX), transform.position.y);
            var m = Instantiate((beatNumber % 2 == 0) ? KickMissile : SnareMissile, spanwPos, Quaternion.Euler(0f, 0f, AngleBetweenTwoPoints(spanwPos, PlayerPosition.position))).GetComponent<Missile>();
            m.SetSpeed(true);
        }

        private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg +90;
        }

    }

}

