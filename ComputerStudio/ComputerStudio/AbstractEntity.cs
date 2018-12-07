using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStudio
{
    public abstract class AbstractEntity
    {  
        private static long id=0;

        public long Id
        {
            get { return id++; }
            
        }

    }
}
