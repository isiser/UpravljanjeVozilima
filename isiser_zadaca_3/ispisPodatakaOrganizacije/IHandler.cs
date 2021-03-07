using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.ispisPodatakaOrganizacije
{
    public interface IHandler
    {
        void SetNext(IHandler handler);
        void Handle(object request);
    }
}
