using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Wilson
{
    public enum SurfaceMaterial
    {
        Oak,
        Laminate,
        Pine,
        Rosewood,
        Veneer
    }

    class Desk
    {
        public int SurfaceArea { get; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public SurfaceMaterial Material { get; set; }
        public int setSurfaceArea()
        {
            try
            {
                return this.Width * this.Depth;
            }
            catch (Exception)
            {
                return 0;                
            }
            
        }
    }
}
