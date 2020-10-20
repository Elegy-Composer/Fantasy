using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fight.Model
{
    public static class BulletConfig
    {
        //this won't be available until Start() is called;
        public static Dictionary<string, GameObject> LordBulletMapping = new Dictionary<string, GameObject>();
    }
}