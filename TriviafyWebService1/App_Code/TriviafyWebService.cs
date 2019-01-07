using HttpMethods;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class TriviafyWebService : IService
{
    public Container container = new Container(
           c => { c.AddRegistry<HttpMethods.Boostrapper>(); });

    public string GetFourRandomSongs(int value)
    {
        var trigger = container.GetInstance<ITriggeringMethods>();
        var fourRandomSongs = trigger.Trigger();

        System.Web.Script.Serialization.JavaScriptSerializer jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return jsonSerializer.Serialize(fourRandomSongs);
        //return null;
    }
}
