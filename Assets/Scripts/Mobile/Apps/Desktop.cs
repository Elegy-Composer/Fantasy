using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mobile.Apps
{
    public class Desktop : MonoBehaviour
    {
        public MobileManager TungPhone;
        public Button CallAppIcon;
        public Button MessageAppIcon;
        // Start is called before the first frame update
        void Start()
        {
            CallAppIcon.onClick.AddListener(delegate { TungPhone.startApp("call"); });
            MessageAppIcon.onClick.AddListener(delegate { TungPhone.startApp("message"); });
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
