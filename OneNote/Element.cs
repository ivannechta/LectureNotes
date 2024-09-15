using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNote
{
    enum ELEMENT_TYPES
    { 
        ELEMENT_TYPE_LINE,
        ELEMENT_TYPE_ARROW,
        ELEMENT_TYPE_TEXT,
        ELEMENT_TYPE_PICTURE,
        ELEMENT_TYPE_ELLIPSE,
    }
    struct ElementCounter {  internal static int TotalElements = 0; }

    internal abstract class Element
    {
        private readonly int ElementId;
        public readonly ELEMENT_TYPES elementType;
        protected readonly Form1 context;
        public float x1, y1;
        public Element(ELEMENT_TYPES t,Form1 _c)
        {
            this.elementType = t;
            this.context = _c;

            ElementId = ElementCounter.TotalElements++;
        }
        public abstract void StartDraw(View v, int _x, int _y);
        public abstract void StopDraw(Form1 _form, View _v);
        public abstract void Move(View v,int _x, int _y);
        public abstract void Draw(View v, bool isSelected,bool isAxes);
        public abstract void Save(FileStream _fs);
        public abstract void Load(FileStream _fs);
    }
}
