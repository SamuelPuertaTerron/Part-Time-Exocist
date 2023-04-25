using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace PartTimeExocist {

    //Waiting for raycast to finish

    public class DarkAreaDetector : MonoBehaviour {
        // A reference to the AR session's light estimation component
        public ARSessionOrigin sessionOrigin;

        // The minimum ambient light intensity that we consider "dark"
        public float darkThreshold = 0.15f;

        // void Update()
        // {
        // Get the current light estimation data from the AR session
        //   LightEstimationData lightData = sessionOrigin.GetComponent<LightEstimation>().lightEstimation;

        // Check if the ambient intensity is below the dark threshold
        //  if (lightData.averageBrightness < darkThreshold)
        //  {
        // The environment is considered "dark"
        //   Debug.Log("It's dark in here!");
        //  }
        // }
    }
}


