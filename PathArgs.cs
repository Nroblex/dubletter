using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dubletter
{
    class PathArgs : EventArgs
    {
        private string _path = "";
        public PathArgs(string path)
        {
            _path = path;
        }
    }
}
