using System;
using System.Collections.Generic;
using System.Text;

namespace Chain
{
    interface AccountsChain
    {
        #nullable enable
        public AccountsChain? Next { get; set; }
        #nullable disable

        public void Pay(int amount);
    }
}
