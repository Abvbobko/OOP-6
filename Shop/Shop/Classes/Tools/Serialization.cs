using CipherInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shop.Tools;

namespace Shop.Tools
{
    abstract class SerializationBody
    {
        public abstract void Serialize(string fileName, List<object> list);
    }

    class SimpleTextSerialization : SerializationBody
    {
        public override void Serialize(string fileName, List<object> list) {
            using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default)) {
                for (int i = 0; i < list.Count; i++) {
                    Type type = list[i].GetType();
                    if (type.IsSerializable) {
                        sw.WriteLine($"({type})<");
                        foreach (PropertyInfo property in list[i].GetType().GetProperties()) {
                            sw.WriteLine($"{property.Name}={property.GetValue(list[i])}");
                        }
                        foreach (FieldInfo field in list[i].GetType().GetFields()) {
                            sw.WriteLine($"{field.Name}={field.GetValue(list[i])}");
                        }
                        sw.WriteLine(">");
                    }
                }
            }
        }
    }

    class SerializationWithEncryption : SerializationBody
    {
        public override void Serialize(string fileName, List<object> list) {
            OpenFileDialog enPluginOpen = new OpenFileDialog();
            enPluginOpen.DefaultExt = "dll";
            enPluginOpen.Filter = "dll files (*.dll)|*.dll";
            if (enPluginOpen.ShowDialog() == DialogResult.OK) {
                try {
                    Assembly asm = Assembly.LoadFrom(enPluginOpen.FileName);
                    Type type = Plugin.DownloadEnDePlugin(asm);
                    var plugin = asm.CreateInstance(type.FullName) as ICipher;
                    string plainText = "";
                    for (int i = 0; i < list.Count; i++) {
                        Type typeOfItem = list[i].GetType();
                        if (typeOfItem.IsSerializable) {
                            plainText += $"({typeOfItem})<\n";
                            foreach (PropertyInfo property in list[i].GetType().GetProperties()) {
                                plainText += $"{property.Name}={property.GetValue(list[i])}\n";
                            }
                            foreach (FieldInfo field in list[i].GetType().GetFields()) {
                                plainText += $"{field.Name}={field.GetValue(list[i])}\n";
                            }
                            plainText += ">\n";
                        }
                    }
                    plainText = plainText.Remove(plainText.Length - 1);
                    using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default)) {
                        sw.Write(plugin.Encrypt(plainText));
                    }
                    MessageBox.Show("It's encrypted.");
                }
                catch {
                    MessageBox.Show("Failed to load plugin or error in plugin's work.");
                }
            }
        }

    }

    abstract class Decorator : SerializationBody
    {
        protected SerializationBody serialize;

        public void SetComponent(SerializationBody serializeMethod) {
            this.serialize = serializeMethod;
        }

        public override void Serialize(string fileName, List<object> list) {
            if (serialize != null) {
                serialize.Serialize(fileName, list);
            }             
        }
    }

    class Serialization : Decorator
    {
       public void SerializeObjects(List<object> list) {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "txt";
            saveFile.Filter = "txt files (*.txt)|*.txt";
            try {
                if (saveFile.ShowDialog() == DialogResult.OK) {
                    base.Serialize(saveFile.FileName, list);
                }
                MessageBox.Show("It's serialized.");
            }
            catch (Exception error) {
                MessageBox.Show(error.Message, "Error");
            }
            
       } 
    }

    static class Deserialization
    {

        struct FAndV
        {
            public string Name;
            public string Value;

            public FAndV(string name, string value) {
                Name = name;
                Value = value;
            }
        }

        private static string FindFieldByName(List<FAndV> fields, string ParameterName) {
            foreach (FAndV field in fields) {
                if (field.Name == ParameterName) {
                    fields.Remove(field);
                    return field.Value;
                }
            }
            return "";
        }

        public static ObjEnumerator Deserialize(List<string> lines) {
            int i = 0;
            ObjEnumerator resultList = new ObjEnumerator();
            while (i < lines.Count) {
                if (lines[i][0] == '(') {

                    lines[i] = lines[i].Substring(1, lines[i].Length - 3);
                    Type type = Type.GetType(lines[i]);
                    List<FAndV> fields = new List<FAndV>();
                    i++;

                    while (lines[i] != ">") {
                        string[] fieldAndValue = lines[i].Split('=');
                        fields.Add(new FAndV(fieldAndValue[0], fieldAndValue[1]));
                        i++;
                    }
                    i++;

                    ParameterInfo[] constructorParameters = type.GetConstructors()[0].GetParameters();

                    object[] allPrms = new object[constructorParameters.Length];
                    for (int j = 0; j < constructorParameters.Length; j++) {
                        string parameterName = char.ToUpper(constructorParameters[j].Name[0]) + constructorParameters[j].Name.Remove(0, 1);
                        allPrms[j] = Convert.ChangeType(FindFieldByName(fields, parameterName), constructorParameters[j].ParameterType);
                    }

                    object obj = Activator.CreateInstance(type, allPrms);
                    List<PropertyInfo> properties = new List<PropertyInfo>(obj.GetType().GetProperties());
                    foreach (FAndV field in fields) {
                        foreach (PropertyInfo property in properties) {
                            if (field.Name == property.Name) {
                                if (property.CanWrite) {
                                    property.SetValue(obj, Convert.ChangeType(field.Value, property.PropertyType));
                                }
                                properties.Remove(property);
                                break;
                            }
                        }
                    }
                    resultList.Add(obj);
                }
            }
            return resultList;
        }

        static public ObjEnumerator DeserializeWithDe(string fileName) {
            using (StreamReader sr = new StreamReader(fileName)) {
                string cipherText = sr.ReadToEnd();

                OpenFileDialog dePluginOpen = new OpenFileDialog();
                dePluginOpen.DefaultExt = "dll";
                dePluginOpen.Filter = "dll files (*.dll)|*.dll";
                if (dePluginOpen.ShowDialog() == DialogResult.OK) {
                try {
                        Assembly asm = Assembly.LoadFrom(dePluginOpen.FileName);
                        Type type = Plugin.DownloadEnDePlugin(asm);
                        var plugin = asm.CreateInstance(type.FullName) as ICipher;                        
                        string plainText = plugin.Decrypt(cipherText);
                        List<string> serObj = new List<string>();
                        string[] serStrigs = plainText.Split('\n');
                        foreach (string oneString in serStrigs) {
                            serObj.Add(oneString);
                        }
                    
                    
                        return Deserialize(serObj);
                    }
                    catch {
                        MessageBox.Show("Failed to load plugin or error in plugin's work.");
                        return null;
                   }
                }
                return null;
            }
        }
    }
}
