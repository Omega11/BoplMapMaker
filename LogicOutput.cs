﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MapMaker
{
    public class LogicOutput
    {
        public LogicOutput() 
        {
            outputs = new List<LogicInput>();
        }
        public ulong UUid;
        //must be set before registering your gate
        public LogicGate gate;
        public bool IsOn;
        public bool WasOnLastTick;
        //these are connected to the output of this gate
        public List<LogicInput> outputs;
    }
}
