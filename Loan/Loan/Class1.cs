using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Loan
{
    public class PecuniaException : ApplicationException
    {
        public PecuniaException()
            : base()
        {
        }

        public PecuniaException(string message)
            : base(message)
        {
        }
        public PecuniaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
    public class Loan
    {
        //Fields
        private string loan_ID;
        private string _loan_type;
        private double _loan_amt;
        private string _loan_status;
        private float _tenure;
        private double _income;
        private string identity;
        private double years_of_service;
        private DateTime loan_upload_date;

        //Properties

        public string Loan_type
        { get; set; }


        public Double Loan_Amt {
            get
            {
                return _loan_amt;
            }
            set
            {
                if ((value > 50000) && (value < 10000000))
                {
                    _loan_amt = value;

                }
                else
                {
                    Console.WriteLine("Loan amount should be between 50 thousand and 1 Crore");
                }

            }
        }

        public string Loan_Status { get; set; }
        public float Tenure
        {
            get
            {
                return _tenure;
            }
            set
            {
                if (value > 0)
                {
                    _tenure = value;

                }
                else
                {
                    Console.WriteLine(" Tenure should be of atleast 1 year");
                }

            }
        }
   
        public double YearlyIncome { get; set; }

        public string Identity { get; set; }
        public double Years_of_service { get; set; }
    }

    public class LoanServices
    {
        public static List<Loan> LoanList = new List<Loan>();
        public bool new_loan(string CustId )
        {

            //For loop for matching customer id with list if matches then proceed if not ask them to add in customer

            Loan Aloan = new Loan();
            bool LoanAdded = false;

            try
            {
                LoanList.Add(Aloan);
                LoanAdded = true;

            }
            catch (SystemException ex)
            {
                throw new PecuniaException(ex.Message); //pecunia xception class will be linked
            }


            switch (Aloan.Loan_type)
            {
                case "Car":
                    {
                        CarLoan cl = new CarLoan();
                        cl.carloan(cl);
                        break;
                    }
            }

                    return LoanAdded;
            }
        public void update_loan(string field) { }
        public void loan_approved() { }//function should be bool 
        public void EMI_Calculator() { }//function should be double return 

        //Loan By Status single function 
        public void loan_Approved() { }
        public void loan_Rejected() { }
        public void loan_InProgress() { }
        public void loan_Pending() { }

        //Loan By date
        public void Loan_By_date() { }
        //Loan By Type
        public void Loan_By_Type(string Loan_Status) { }
        //loan by loan Id
        public void Loan_By_ID(string Loan_ID) { }
        //loan by amount
        public void Loan_By_Amt() { }
    }

    //Car Loan
    public class CarLoan : Loan
    {
        private string license;
        public static List<CarLoan> employeeList = new List<CarLoan>();//doubt always same list will be appended in case we go out of class during 1 console use

        public bool carloan(CarLoan carloan)
        {
            bool CarAdded = false;
            try
            { // we have to write  get license here ?
                employeeList.Add(carloan);
                CarAdded = true;
            }
            catch (SystemException ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return CarAdded;

        }
    }

    //Home Loan
    public class HomeLoan : Loan
    {
        private double collateral;
        public static List<HomeLoan> employeeList = new List<HomeLoan>();

        public bool AddEmployeeDL(Employee newEmployee)
        {
            bool employeeAdded = false;
            try
            {
                employeeList.Add(newEmployee);
                employeeAdded = true;
            }
            catch (SystemException ex)
            {
                throw new EmsException(ex.Message);
            }
            return employeeAdded;

        }

    }

    //Education Loan
    public class EducationLoan : Loan
    {
        private double collateral;
        private string sponseror;
        private string college_name;
        private string admission_ID;
    }

    //Personal Loan
    public class PersonalLoan : Loan
    {
        private double collateral;
    }
}
