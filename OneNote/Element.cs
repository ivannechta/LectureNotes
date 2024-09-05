﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNote
{
    enum ELEMENT_TYPES
    { 
        ELEMENT_TYPE_LINE,        
    }
    struct ElementCounter {  internal static int TotalElements = 0; }

    internal abstract class Element
    {
        private readonly int ElementId;
        public readonly ELEMENT_TYPES elementType;
        protected readonly Form1 context;
        public double x1, y1;
        public Element(ELEMENT_TYPES t,Form1 _c) 
        {
            this.elementType = t;
            this.context = _c;

            ElementId = ElementCounter.TotalElements++;
        }
        public abstract void StartDraw(View v, int _x, int _y);
        public abstract void Move(View v,int _x, int _y);
        public abstract void Draw(View v);
    }
}
