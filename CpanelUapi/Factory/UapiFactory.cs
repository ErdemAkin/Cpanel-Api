using CpanelUapi.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace CpanelUapi.Factory
{
    class UapiFactory
    {
        public object CallApi(string className)
        {
            string @namespace = "CpanelUapi.Api";
            string @class = className;

            var myClassType = Type.GetType(String.Format("{0}.{1}", @namespace, @class));
            var instance = myClassType == null
                ? throw new ArgumentException(className + " isimli class bulunamadı.")
                : Activator.CreateInstance(myClassType);
            
            return instance;
        }
    }
}
