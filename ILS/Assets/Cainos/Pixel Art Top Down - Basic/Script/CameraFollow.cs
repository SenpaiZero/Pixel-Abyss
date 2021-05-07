using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float lerpSpeed = 2.5f;
        public bool isWave = false;

        public Vector3 offset = new Vector3(0,0,0);

        private Vector3 targetPos;

        private void Start()
        {
            if (target == null) return;
            transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
            offset = transform.position - target.position;
        }

        private void Update()
        {
            if (target == null) return;


            if(isWave == true)
            {

                targetPos = target.position + offset;
                transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos.x, targetPos.y - 0.5f, targetPos.z), lerpSpeed * Time.deltaTime);
            }
            else
            {

                targetPos = target.position + offset;
                transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
            }
        }

    }
}
