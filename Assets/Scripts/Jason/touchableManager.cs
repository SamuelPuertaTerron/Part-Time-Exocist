using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PartTimeExocistOld {

    // Have Changed this to use the new input system

    public class TouchableManager : MonoBehaviour {
        public LayerMask touchInputMask;
        private List<GameObject> touchList = new List<GameObject>();
        private GameObject[] touchesOld;
        private RaycastHit hit;
        private Transform player;
        private bool _foundplayer;

        void Start() {
            _foundplayer = false;
        }
        void Update() {
            if (_foundplayer == false) {
                player = GameObject.FindGameObjectWithTag("MainCamera").transform;
            }
            if (_foundplayer) {
                transform.LookAt(player);
            }


            if (Input.touchCount > 0) {
                touchesOld = new GameObject[touchList.Count];
                touchList.CopyTo(touchesOld);
                touchList.Clear();

                foreach (Touch touch in Input.touches) {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);    //attached the main camera

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchInputMask.value)) {
                        GameObject recipient = hit.transform.gameObject;
                        touchList.Add(recipient);

                        if (touch.phase == TouchPhase.Began) {
                            Debug.Log("Touched: " + recipient.name);
                            recipient.SendMessage("onTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                        }

                        if (touch.phase == TouchPhase.Ended) {
                            recipient.SendMessage("onTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                        }

                        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                            recipient.SendMessage("onTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                        }

                        if (touch.phase == TouchPhase.Canceled) {
                            recipient.SendMessage("onTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
                foreach (GameObject g in touchesOld) {
                    if (!touchList.Contains(g)) {
                        g.SendMessage("onTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }
}


