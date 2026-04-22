using System;
using System.Collections.Generic;

namespace ContractorProject
{
    // =========================
    // CONTRACTOR CLASS (DONE)
    // =========================
    public class Contractor
    {
        private string contractorName;
        private int contractorNumber;
        private DateTime startDate;

        public Contractor(string name, int number, DateTime date)
        {
            contractorName = name;
            contractorNumber = number;
            startDate = date;
        }

        // Getters
        public string GetName() => contractorName;
        public int GetNumber() => contractorNumber;
        public DateTime GetStartDate() => startDate;

        // Setters
        public void SetName(string name) => contractorName = name;
        public void SetNumber(int number) => contractorNumber = number;
        public void SetStartDate(DateTime date) => startDate = date;
    }

    // =========================
    // SUBCONTRACTOR CLASS (DONE)
    // =========================
    public class Subcontractor : Contractor
    {
        private int shift; // 1 = Day, 2 = Night
        private double hourlyPayRate;

        public Subcontractor(string name, int number, DateTime date, int shift, double payRate)
            : base(name, number, date)
        {
            this.shift = shift;
            this.hourlyPayRate = payRate;
        }

        public int GetShift() => shift;
        public double GetPayRate() => hourlyPayRate;

        // PAY CALCULATION (DONE)
        public float CalculatePay(float hoursWorked)
        {
            double pay = hourlyPayRate * hoursWorked;

            // Night shift bonus (3%)
            if (shift == 2)
            {
                pay *= 1.03;
            }

            return (float)pay;
        }

        /*
        ===========================================================
        🚨 PARTNER TODO SECTION (THIS IS YOUR HALF OF THE PROJECT)
        ===========================================================

        1. ADD OVERTIME PAY
           - If hours > 40, extra hours should be paid at 1.5x rate
           - Example logic:
                if (hoursWorked > 40)
                {
                    regular = 40 hours
                    overtime = hoursWorked - 40
                }

        2. IMPROVE THIS METHOD
           - Combine:
                base pay
                + overtime
                + shift differential

        3. OPTIONAL (FOR HIGHER GRADE)
           - Add method:
                public string GetShiftName()
                return "Day" or "Night"

        */
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Subcontractor> workers = new List<Subcontractor>();

            Console.WriteLine("Enter number of subcontractors:");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nSubcontractor #{i + 1}");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Start Date (yyyy-mm-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Shift (1 = Day, 2 = Night): ");
                int shift = int.Parse(Console.ReadLine());

                Console.Write("Hourly Pay Rate: ");
                double rate = double.Parse(Console.ReadLine());

                Subcontractor sc = new Subcontractor(name, number, date, shift, rate);
                workers.Add(sc);
            }

            Console.WriteLine("\n--- Payroll ---");

            foreach (var worker in workers)
            {
                Console.Write($"\nEnter hours worked for {worker.GetName()}: ");
                float hours = float.Parse(Console.ReadLine());

                float pay = worker.CalculatePay(hours);

                Console.WriteLine($"Total Pay: ${pay:F2}");

                /*
                ===========================================================
                🚨 PARTNER TODO (MAIN PROGRAM IMPROVEMENTS)
                ===========================================================

                1. DISPLAY MORE INFO
                   - Print:
                        Contractor Number
                        Start Date
                        Shift (Day/Night)

                2. INPUT VALIDATION
                   Replace risky lines like:
                        int.Parse()
                   with:
                        int.TryParse()

                3. MENU SYSTEM (OPTIONAL)
                   - Let user:
                        Add more workers
                        View payroll again

                4. CLEAN CODE
                   - Move input logic into separate methods like:
                        CreateSubcontractor()

                */
            }

            /*
            ===========================================================
            🚨 FINAL PARTNER TASKS
            ===========================================================

            - Add comments explaining:
                Inheritance
                Encapsulation
                How pay is calculated

            - Help write second half of report:
                Improvements
                Challenges
                Future expansion

            */
        }
    }
}