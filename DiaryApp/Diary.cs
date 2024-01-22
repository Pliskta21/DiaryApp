using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiaryApp
{
    public class diary
    {
        public List<events> veci = new List<events>();

        public void Data()
        {
            Console.WriteLine(veci);
            string jsonString = JsonConvert.SerializeObject(veci);

            Console.WriteLine(jsonString);
            File.WriteAllText("Data.json", jsonString);
        }
        public void json_load()
        {
            string jsonString = File.ReadAllText("Data.json");

            veci = JsonConvert.DeserializeObject<List<events>>(jsonString);

        }
    }

}
