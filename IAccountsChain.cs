using System;
using System.Collections.Generic;
using System.Text;

namespace Chain
{
    interface IAccountsChain
    {
        #nullable enable
        public IAccountsChain? Next { get; set; }
        #nullable disable

        public void Pay(int amount);
    }
}
