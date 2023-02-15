using System;
namespace test_automation_2023
{
    public class Device
    {
        public string name;
        private int _width;
        private int _height;

        public int width
        {
            get
            { return _width; }
            set
            {
                if (_width < 320)
                {
                    _width = 320;
                }
            }
        }

        public int height
        {
            get
            {
                return _height;
            }
            set
            {
                if(_height < 400)
                {
                    _height = 400;
                }
            }
        }

        


    }
}

