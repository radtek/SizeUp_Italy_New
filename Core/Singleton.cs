﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core
{
    public static class Singleton<T> where T : new()
    {
        private static T _instance;
        private static object syncLock = new object();
        public static T Instance
        {
            get
            {

                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}