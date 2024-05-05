using LinkedSpace.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace RectangularSpaceDisplay
{
    public class SimulationsContainer
    {
        private readonly Dictionary<string, Simulation> _simulations = new Dictionary<string, Simulation>();

        private readonly Dictionary<string, string> _names = new Dictionary<string, string>();
        public Dictionary<string, string> Names => _names;

        public Simulation this[string id] => _simulations[id];

        public SimulationsContainer()
        {
            List<AddIn> addIns = new List<AddIn>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<AddIn>));

            DirectoryInfo current = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach(FileInfo file in current.GetFiles("*.addin", SearchOption.TopDirectoryOnly))
            {
                using (FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    addIns.AddRange(serializer.Deserialize(fs) as IEnumerable<AddIn>);
                }
            }

            foreach(AddIn addIn in addIns)
            {
                Assembly assembly = Assembly.LoadFrom($"{current}\\{addIn.Assembly}");
                Type type = assembly.GetType(addIn.FullClassName);
                ConstructorInfo constructorInfo = type.GetConstructor(new Type[] {});
                _simulations.Add(addIn.AddInId, (Simulation)constructorInfo.Invoke(new object[] { }));
                _names.Add(addIn.AddInId, addIn.Name);
            }
        }
    }
}