using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadPolarBear
{
    internal class SkillNode
    {
        public string Name { get; set; }
        public List<string> data = new List<string>();
        public SkillNode() { }
        public SkillNode(string name) {
            this.Name = name;
        }
        public void AddData(string data)
        {
            this.data.Add(data);
        }
        public void Initial()
        {
            this.Name = "";
            data.Clear();
        }
    }

    internal class Province
    {
        public string Name { get; set; }
        public Province(string name) { 
            this.Name = name;
        }
        public List<SkillNode> skillList = new List<SkillNode>();
        public void Add(SkillNode skillNode)
        {
            this.skillList.Add(skillNode);
        }

    }
}
