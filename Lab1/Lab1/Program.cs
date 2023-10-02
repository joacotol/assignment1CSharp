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
using System.IO;

namespace Lab1
{
    /// <summary>
    /// The View of the program
    /// Gives user options on how to interact with the program
    /// Outputs the employee data based on the employee text file provided
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            // Path to the employees.txt file
            string path = Path.Combine(Directory.GetCurrentDirectory(), "employees.txt");
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader data = new StreamReader(file);

            // The array that will store the employee records
            // Can store 100 employees
            Employee[] employees = new Employee[100];
            // Extract the data from the text file and store it to the employees array
            Read(file, data, employees);

            bool isExit = false;

            // The VIEW
            while (!isExit)
            {
                Console.WriteLine("\n\n=====================================\n");
                Console.WriteLine("1. Sort by Employee Name (ascending)");
                Console.WriteLine("2. Sort by Employee Number (ascending)");
                Console.WriteLine("3. Sort by Employee Pay Rate (descending)");
                Console.WriteLine("4. Sort by Employee Hours (descending)");
                Console.WriteLine("5. Sort by Employee Gross Pay (descending)");
                Console.WriteLine("6. Exit");
                Console.WriteLine("\n\n=====================================\n");

                string input = Console.ReadLine();
                Console.WriteLine();

                // Checks if the input is a number, resets if it's not
                if ( !int.TryParse(input, out _)) {
                    Console.WriteLine("That is not a number. Try again.");
                    continue;
                }

                switch (int.Parse(input))
                {
                    case 1:
                        Sort(employees, 1);
                        PrintEmployees(employees);
                        break;
                    case 2:
                        Sort(employees, 2);
                        PrintEmployees(employees);
                        break;
                    case 3:
                        Sort(employees, 3);
                        PrintEmployees(employees);
                        break;
                    case 4:
                        Sort(employees, 4);
                        PrintEmployees(employees);
                        break;
                    case 5:
                        Sort(employees, 5);
                        PrintEmployees(employees);
                        break;
                    case 6:
                        isExit = true; // EXITS THE PROGRAM
                        break;
                    default:
                        Console.WriteLine("Not a valid number.");
                        break;
                }

            }
        }
        /// <summary>
        /// This will read the file and put the elements in an Employee[] array
        /// </summary>
        /// <param name="fs">The file that is being used to read</param>
        /// <param name="data">Reads from the file</param>
        /// <param name="employees">The array that will be used to store data</param>
        static void Read(FileStream fs, StreamReader data, Employee[] employees)
        {
            // counts the number elements in the Employee[] array that is not null
            int count = 0;
            string line;
            // It will iterate per line until the end of the file
            while ( (line = data.ReadLine() ) != null)
            {
                // For every single line split them into elements of an array and put each data 
                // in to the corresponding values
                string[] inputs = line.Split(',');
                string name = inputs[0];
                int number = int.Parse(inputs[1]);
                decimal rate = decimal.Parse(inputs[2]);
                double hours = double.Parse(inputs[3]);
                // Add the Employee object to the array based on the data that was provided by a single line
                employees[count] = new Employee(name, number, rate, hours);
                count++;
                
            }
            fs.Close();
            data.Close();
            
        }

        /// <summary>
        /// Sorts the Employee[] array based on a variey of factors such as either 
        /// descending or ascending order as well as the fields that are being sorted.
        /// 
        /// The sorting algorithm that I used for this assignment is a selection sort, the source that 
        /// I used to help implement this program is below:
        /// https://www.tutorialspoint.com/data_structures_algorithms/selection_sort_algorithm.htm
        /// 
        /// </summary>
        /// <param name="employees">The array that is being sorted</param>
        /// <param name="userChoice">The user choice is based on what the user has chosen 
        /// which data they want to sort</param>
        static void Sort(Employee[] employees, int userChoice)
        {
            // Only counts the elements that are not null
            int arrayLength = employees.Count(element => element != null);

            // Sort by Employee Number 
            if (userChoice == 2)
            {
                // It will continually compare the selected value until there is a value
                // that is less than that selected value
                // it then swaps the index between those values to the correct
                // ascended order
                for (int selected = 0; selected < arrayLength - 1; selected++)
                {
                    int minIndex = selected; // the selected index
                    for (int compared = selected + 1; compared < arrayLength; compared++)
                    {
                        //Console.WriteLine(employees[minIndex].GetNumber());
                        if (employees[compared].GetNumber() < employees[minIndex].GetNumber())
                        {
                            minIndex = compared; // minimum index is changed to a new value
                        }

                    }
                    // Swaps the new value to the previously selected value's index
                    Employee temp = employees[minIndex];
                    employees[minIndex] = employees[selected];
                    employees[selected] = temp;
                }
            // Sort by Employee Pay Rate
            } else if (userChoice == 3)
            {
                for (int selected = 0; selected < arrayLength - 1; selected++)
                {
                    int maxIndex = selected;
                    for (int compared = selected + 1; compared < arrayLength; compared++)
                    {
                        // Descending order so the compared value has to be higher in order to be sorted
                        // correctly 
                        if (employees[compared].GetRate() > employees[maxIndex].GetRate())
                        {
                            maxIndex = compared; // Max index is changed for the next highest value
                        }
                    }

                    // Swap Index
                    Employee temp = employees[maxIndex];
                    employees[maxIndex] = employees[selected];
                    employees[selected] = temp;
                }
            // Sort by Employee Hours
            } else if (userChoice == 4)
            {
                for (int selected = 0; selected < arrayLength - 1; selected++)
                {
                    int maxIndex = selected;
                    for (int compared = selected + 1; compared < arrayLength; compared++)
                    {
                        // Descending Order
                        if (employees[compared].GetHours() > employees[maxIndex].GetHours())
                        {
                            maxIndex = compared;
                        }
                    }
                    
                    Employee temp = employees[maxIndex];
                    employees[maxIndex ] = employees[selected];
                    employees[selected] = temp;
                }
            // Sort by Employee Gross Pay
            } else if (userChoice == 5)
            {
                for (int selected = 0; selected < arrayLength - 1; selected++)
                {
                    int maxIndex = selected;
                    for (int compared = selected + 1; compared < arrayLength; compared++)
                    {
                        // Descending Order
                        if (employees[compared].GetGross() > employees[maxIndex].GetGross())
                        {
                            maxIndex = compared;
                        }
                    }
                    Employee temp = employees[maxIndex];
                    employees[maxIndex] = employees[selected];
                    employees[selected] = temp;
                }
            // Sort by Employee Name
            } else
            {
                for (int selected = 0; selected < arrayLength - 1; selected++)
                {
                    int minIndex = selected;
                    for (int compared = selected + 1; compared < arrayLength; compared++)
                    {
                        // Compares both strings and check which one is of the higher
                        // alphabetical order, OrdinalIgnoreCase ignores uppercase
                        // if comparison is less than two then the compared value is higher
                        // and replaces the minIndex 
                        if (string.Compare(employees[compared].GetName(), employees[minIndex].GetName(),
                            StringComparison.OrdinalIgnoreCase) < 0)
                        {

                            minIndex = compared;

                        }
                    }
                    Employee temp = employees[minIndex];
                    employees[minIndex] = employees[selected];
                    employees[selected] = temp;
                }
            }
            
        }

        /// <summary>
        /// Prints the Employee[] array ignoring null elements
        /// </summary>
        /// <param name="employees">The array that is being outputted</param>
        static void PrintEmployees(Employee[] employees)
        {
            foreach (Employee employee in employees)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }
}
