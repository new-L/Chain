using System;

namespace Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountsChain payment = new Bank("Bank", 300, new PayPal("Paypal", 200, new Bitcoin("Bitcoin", 700)));
            payment.Pay(20);

            Console.ReadKey();
        }


        class Account : AccountsChain
        {
            public string m_Name;
            public int m_Balance;
#nullable enable
            private AccountsChain? _next;
#nullable disable
            public AccountsChain Next  // read-write instance property
            {
                get => _next;
                set => _next = value;
            }
            public Account(string name, int balance, AccountsChain next = null)
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



        #region Конкретные обработчики
        class Bank : Account
        {
            public Bank(string name, int balance, AccountsChain next = null) : base(name, balance, next) { }
        }
        class PayPal : Account
        {
            public PayPal(string name, int balance, AccountsChain next = null) : base(name, balance, next) { }
        }
        class Bitcoin : Account
        {
            public Bitcoin(string name, int balance, AccountsChain next = null) : base(name, balance, next) { }
        }
        #endregion



    }

  
}
