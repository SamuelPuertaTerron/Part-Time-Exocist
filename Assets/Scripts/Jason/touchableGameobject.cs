using UnityEngine;
using System.Collections;

namespace PartTimeExocist {

    //No Longer use
    public class TouchableGameObject : MonoBehaviour {
        public Color defaultColor;
        public Color selectedColor;
        private Material mat;
        private Transform player;
        public float speed = 5.0f;
        public float delay = 3.0f;
        public float radius = 0.5f;
        public new SpriteRenderer renderer;

        private float startTime;


        void Start() {
            renderer = GetComponent<SpriteRenderer>();
            mat = GetComponent<Renderer>().material;
            startTime = Time.time;
        }

        void Update() {

            player = GameObject.FindGameObjectWithTag("MainCamera").transform;
            transform.LookAt(player);
            float distance = Vector3.Distance(transform.position, player.position);
            if (Time.time >= startTime + delay) {
                //move towards player
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            if (distance <= radius && Time.time >= startTime + delay) {

                renderer.material.color = Color.red;
            } else {
                // Change back to orginal colour
                renderer.material.color = Color.white;
            }

            Debug.Log(player);
        }
    }
}

