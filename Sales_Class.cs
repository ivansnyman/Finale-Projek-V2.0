using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Projek_V2._0
{
    class Sales_Class
    {
        private int transaction_ID, cust_ID, emp_ID, prod_ID;
        private double amount;
        private string date;
        private string products;
        public int Trans_ID
        {
            get
            {
                return this.transaction_ID;
            }
            set
            {
                this.transaction_ID = value;
            }
        }

        public int Cust_ID
        {
            get
            {
                return this.cust_ID;
            }
            set
            {
                this.cust_ID = value;
            }
        }

        public int Emp_ID
        {
            get
            {
                return this.emp_ID;
            }
            set
            {
                this.emp_ID = value;
            }
        }

        public int Prod_ID
        {
            get
            {
                return this.prod_ID;
            }
            set
            {
                this.prod_ID = value;
            }
        }

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }

        //Default constructor
        public Sales_Class()
        {
            this.transaction_ID = 0;
            this.cust_ID = 0;
            this.emp_ID = 0;
            this.prod_ID = 0;
            this.amount = 0;
            this.date = "";
            this.products = "";
        }

        //Constructor
        public Sales_Class(int transaction_ID, int cust_ID, int emp_ID, int prod_ID, double amount, string date, string products)
        {
            this.transaction_ID = transaction_ID;
            this.cust_ID = cust_ID;
            this.emp_ID = emp_ID;
            this.prod_ID = prod_ID;
            this.amount = amount;
            this.date = date;
            this.products = products;
        }


    }
}
