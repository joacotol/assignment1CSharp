/// Joaquin Tolentino,  000771944
/// 2023-09-22
/// This program is used to create a CLI to show employee records
/// based on user's choice on sorted values
/// I, Joaquin Tolentino, 000771944, certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// The Employee object that holds values for an employee's name, employee number,
    /// their hourly rate, the number of hours worked and their gross income.
    /// </summary>
    public class Employee
    {

        private string name;
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;

        /// <summary>
        /// Class constructor for the Employee Class
        /// </summary>
        /// <param name="name">Name of the employee</param>
        /// <param name="number">Employee's number</param>
        /// <param name="rate">Employee's hourly rate</param>
        /// <param name="hours">Number of hours worked</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        /// <summary>
        /// Returns the gross income of an employee,
        /// If they worked more than 40 hours then they
        /// get paid time and a half for their work.
        /// </summary>
        /// <returns>Returns the gross income</returns>
        public decimal GetGross()
        {
            if (this.hours > 40)
            {
                this.gross = (this.rate * (decimal)1.5) * (decimal)this.hours;
            }
            else
            {
                this.gross = this.rate * (decimal)this.hours;
            }
            return this.gross;
        }

        /// <summary>
        /// Returns the number of hours worked
        /// </summary>
        /// <returns>Returns the number of hours</returns>
        public double GetHours() {
            return this.hours;
        }

        /// <summary>
        /// Return's the employee's name
        /// </summary>
        /// <returns>Return's the name</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// Returns the employee number
        /// </summary>
        /// <returns>Returns the number</returns>
        public int GetNumber() { return this.number; }

        /// <summary>
        /// Returns the hourly rate
        /// </summary>
        /// <returns>Returns the rate</returns>
        public decimal GetRate() { return this.rate;}

        /// <summary>
        /// Sets the number of hours worked
        /// </summary>
        /// <param name="hours">The number of hours worked</param>
        public void SetHours(double hours)
        {
            this.hours = hours;
        }

        /// <summary>
        /// Sets the name of the employee
        /// </summary>
        /// <param name="name">The name of the employee</param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Sets the employee number
        /// </summary>
        /// <param name="number">The employee number</param>
        public void SetNumber(int number)
        {
            this.number = number;
        }

        /// <summary>
        /// Sets the hourly rate
        /// </summary>
        /// <param name="rate">Hourly rate</param>
        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }

        /// <summary>
        /// The ToString method that returns all the values of an object
        /// </summary>
        /// <returns>All values in the object</returns>
        override
        public string ToString()
        {
            return $"Name: {GetName()}\t Number: {GetNumber()}\t Rate: {GetRate():C}\t" +
                $" Hours: {GetHours()}\t Gross Pay: {GetGross():C}";
        }
    }
}
