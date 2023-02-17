using System;
namespace test_automation_2023
{
    public class Device
    {
        
        private int _width { get; set; }
        private int _height { get; set; }

        public int width
        {
            get { return _width; }
            set
            {
                if (_width < 320)
                {
                    value = 320;
                }
                else { value = _width; }
            }
        }

        public int height
        {
            get { return _height; }
            set
            {
                if (_height < 400)
                {
                    value = 400;
                }
                else { value = _width; }
            }
        }
    }
}


