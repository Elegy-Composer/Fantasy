using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MapObject.Movement;

namespace Mobile
{
    public class MobileManager : MonoBehaviour
    {
        public GameObject TungPhone;
        public Button HomeButton;
        public MobileStorage storage;
        public Rigidbody2D body;
        public GameObject DesktopApp;
        public GameObject CallApp;
        public GameObject MessageApp;
        private Dictionary<string, GameObject> Apps = new Dictionary<string, GameObject>();

        private bool _open = false;
        public bool isMobileOpen
        {
            get { return _open; }
            set {
                _open = value;
                TungPhone.SetActive(value);
            }
        }

        void Start()
        {
            if (Apps.Count == 0)
            {
                Apps.Add("desktop", DesktopApp);
                Apps.Add("call", CallApp);
                Apps.Add("message", MessageApp);
            }
            HomeButton.onClick.AddListener(GoDesktop);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                isMobileOpen = !isMobileOpen;
                body.bodyType = isMobileOpen ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
            }
        }

        void GoDesktop()
        {
            Debug.Log("Go Desktop");
            this.startApp("desktop");
        }

        public void startApp(string AppName)
        {
            Debug.Log(AppName);
            foreach(KeyValuePair<string, GameObject> app in Apps)
            {
                if (app.Key == AppName)
                    app.Value.SetActive(true);
                else
                    app.Value.SetActive(false);
            }
        }
    }
}
