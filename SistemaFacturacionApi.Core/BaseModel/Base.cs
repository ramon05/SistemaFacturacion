﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Core.BaseModel
{
    public interface IBase
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
    public class Base : IBase
    {
        public virtual int Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
