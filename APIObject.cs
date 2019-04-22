using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.API
{
    public class APIObject : IDisposable
    {
        int value;
        bool isDisposed;
        public APIObject(int value)
        {
            this.value = value;
            MagicAPI.Allocate(value);
        }

        ~APIObject()
        {
            Dispose(value);
        }

        public void Dispose()
        {
            if (!isDisposed)
                MagicAPI.Free(value);
            GC.SuppressFinalize(this);
            isDisposed = true;
        }

        public void Dispose(int value)
        {
            if (!isDisposed)
                MagicAPI.Free(value);
            isDisposed = true;
        }
    }
}


