using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [PetaPoco.TableName("test")]
    [PetaPoco.PrimaryKey("id", AutoIncrement = false)]
    public class TestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [System.ComponentModel.DisplayName("年龄")]
        public int Age { get; set; }

        public string Verification()
        {
            if (!(this.Age > 0 && this.Age < 200))
            {
                return "您输入的年龄错误！！";
            }
            return "";
        }
    }
}