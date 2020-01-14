using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Colour
    {
        public UInt32 colour
        {
            get
            {
                return (UInt32)(red3 + green3 + blue3 + _alpha);
            }
        }

        private byte _red = 0;
        private byte _green = 0;
        private byte _blue = 0;
        private byte _alpha = 0;
        private int red3;
        private int green3;
        private int blue3;
        public Colour()
        {

        }
        public Colour(byte red, byte green, byte blue, byte alpha)
        {
            _red = red;
            _green = green;
            _blue = blue;
            _alpha = alpha;
            int red2 = _red << 24;
            int green2 = _green << 16;
            int blue2 = _blue << 8;
            red3 = red2;
            green3 = green2;
            blue3 = blue2;
        }
        public byte GetRed()
        {
            return _red;
        }
        public void SetRed(byte input)
        {
            red3 = input << 24;
        }

        public void SetGreen(byte input)
        {
            green3 = input << 16;
        }
        public byte GetGreen()
        {
            return _green;
        }
        public void SetBlue(byte input)
        {
            blue3 = input << 8;
        }
        public byte GetBlue()
        {
            return _blue;
        }
        public void SetAlpha(byte input)
        {
            _alpha = input;
        }
        public byte GetAlpha()
        {
            return _alpha;
        }
    }
}
