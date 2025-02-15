﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_project.Entities
{
    public class Position
    {
        public int PositionID { get; set; }

        public string PositionName { get; set; } = null!;
        public List<Employee> Employees { get; set; } = [];
        public Position(string positionName)
        {
            PositionName = positionName;
        }
    }
}
