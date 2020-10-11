using System;

namespace Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccountsChain payment = new Account("Bank", 100, new Account("Paypal", 200, new Account("Bitcoin", 700)));
            payment.Pay(100);

            Console.ReadKey();
        }

        class Account : IAccountsChain
        {
            public string m_Name;
            public int m_Balance;
            #nullable enable
            private IAccountsChain? m_Next;
            #nullable disable
            public IAccountsChain Next 
            {
                get => m_Next;
                set => m_Next = value;
            }
            public Account(string name, int balance, IAccountsChain next = null)
            {
                m_Name = name;
                m_Balance = balance;
                Next = next;
            }
            public void Pay(int amount) 
            {
                if(CanPay(amount))
                    Console.WriteLine("Вы оплатили {0} со счета {1}", amount, m_Name);
                else
                {
                    if(Next != null)
                        Next.Pay(amount);
                    else
                        Console.WriteLine("На всех счетах недостаточно средств");
                }
            }

            public bool CanPay(int amount)
            {
                return m_Balance >= amount;
            }
        }
    }

}
