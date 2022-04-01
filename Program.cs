using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentII
{
    class Program
    {
        static void Main(string[] args)
        {
            var comapany = new List<Company>()
           {
            new Company() { C_id = 101, C_Name="A" },
            new Company() { C_id =102, C_Name ="B"}
           };

            var groups = new List<Group>()
            {
                new Group() { C_id = 101, G_Name="Window", G_id =1 },
                new Group() { C_id =101,  G_Name="Door  ", G_id =2},
                new Group() { C_id =102,  G_Name="Door  ", G_id =2},
                new Group() { C_id=102,   G_Name="Window", G_id =3},
 
            };

            var items = new List<Item>()
             {
           new Item() { I_id =1, Name = "2T"},
           new Item() { I_id =2, Name ="3T"},
             };

            var spec = new List<Specification>()
            {
            new Specification() { I_id =1, G_id=1,  Code="C1", color ="White"},
            new Specification() { I_id =2, G_id=2,  Code="C2", color ="Golden" },
            new Specification() { I_id =1, G_id =3, Code="C3", color ="Silver"},
            new Specification() { I_id =2, G_id =4, Code="C4", color ="White" },
            new Specification() { I_id =1, G_id=2,  Code="C5", color ="Red" },
            new Specification() { I_id =2, G_id=3,  Code="C6", color ="Red" }
            };

            var group_d = from c in comapany
                          join g in groups on c.C_id equals g.C_id
                          join s in spec on g.G_id equals s.G_id
                          join i in items on s.I_id equals i.I_id
                          select new { c, g, s, i };

            foreach (var item  in group_d)
            {
                Console.WriteLine("Company Name: {0}  |  Group Name: {1}  |  ItemName: {2}   |  Code: {3}  |  Color: {4}", item.c.C_Name,
                    item.g.G_Name, item.i.Name, item.s.Code, item.s.color);
            }

            var comp = from c in comapany
                       join g in groups on c.C_id equals g.C_id into comp_group
                       select new { c, comp_group };

            var sjoin = from s in spec
                        join g in groups on s.G_id equals g.G_id into s_group
                        select new { s, s_group };

            var ijoin = from i in items
                        join s in spec on i.I_id equals s.I_id into i_group
                        select new { i, i_group };
           

            foreach (var item in comp)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("\nComapany Name: {0}", item.c.C_Name);
              
                foreach (var iteml in item.comp_group)
                {
                Console.WriteLine("\nGroup Name : {0}", iteml.G_Name);

                 foreach (var itm in ijoin)
                    {
                Console.WriteLine("\nItem Name: {0}\n",itm.i.Name);

                foreach (var itml in itm.i_group)
                        {
                Console.WriteLine("Item Code: {0}, Item Color: {1}",itml.Code, itml.color);
                        }
                    }
                }
            }


        }

        public class Company
        {
            public int C_id { get; set; }
            public string C_Name { get; set; }

        }

        public class Group
        {
            public int C_id { get; set; }
            public string G_Name { get; set; }
            public int G_id { get; set; }
        }
        public class Item
        {
            public int I_id { get; set; }
            public string Name { get; set; }

        }
        public class Specification
        {
            public int I_id { get; set; }
            public int G_id { get; set; }
            public string Code { get; set; }
            public string color { get; set; }
        }
    }
}
