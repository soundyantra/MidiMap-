using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miditests
{
    class KeyCodePress
    {

            private int keycode;
            public delegate void Method();

            public Method met;

            public void InvokeKey()
            {
                met.Invoke();
            }

            public KeyCodePress(int keycode, Method met)
            {
                this.keycode = keycode;
                this.met = met;
            }
    }
}
