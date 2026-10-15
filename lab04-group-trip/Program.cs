/*
* Name: Braxten Crowell
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 14, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/


//Required Questions
Console.Write("What was the round trip in miles?");
int milesForTheTrip = Convert.ToInt32(Console.ReadLine());

Console.Write("What is the miles per gallon ofthe car you are using?");
int milesPerGallon = Convert.ToInt32(Console.ReadLine());

Console.Write("What was the gas price?");
double gasPrice = Convert.ToDouble(Console.ReadLine());

Console.Write("How many pizzas are you purchasing?");
int pizzasPurchasing = Convert.ToInt32(Console.ReadLine());

Console.Write("What is the pice per pizza?");
double pricePerPizza = Convert.ToDouble(Console.ReadLine());

//Inputs Given
Console.WriteLine("");
Console.WriteLine("Round trip miles: " + milesForTheTrip.ToString("F0"));
Console.WriteLine("Miles per gallon: " + milesPerGallon.ToString("F0"));
Console.WriteLine("Price per gallon: " + gasPrice.ToString("F2"));
Console.WriteLine("How many pizzas: " + pizzasPurchasing.ToString("F0"));
Console.WriteLine("Price per pizza: " + pricePerPizza.ToString("F2"));
Console.WriteLine("");

//Part One: Road Trip


Console.WriteLine("=== Part 1: Road Trip ===");


//Equations

double gallonsNeeded = milesForTheTrip / (double)milesPerGallon;
double fuelCost = gallonsNeeded * gasPrice;
double pizzaCost = pizzasPurchasing * (double)pricePerPizza;
double tripTotal = fuelCost + pizzaCost;

//Write Equation Outcomes

Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));
Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));
Console.WriteLine("Trip total: " + tripTotal.ToString("C"));
Console.WriteLine("");

//Part Two: The Group

Console.WriteLine("=== Part 2: The Group ===");

//Constat

const double slicesPerPizza = 8;

//Arrays

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

//Equations

double totalSlices = pizzasPurchasing * slicesPerPizza;
double slicePerPerson = totalSlices / names.Length;
double tripCostPerPerson = tripTotal / names.Length;

//Write Equation Outcomes


Console.WriteLine("People going: " + names.Length);
Console.WriteLine("Slices each: " + slicePerPerson.ToString("F1"));
Console.WriteLine("Cost per person: " + tripCostPerPerson.ToString("C"));
Console.WriteLine("");

//Part Three: Who Works How Long

Console.WriteLine("=== Part 3: Who Works How Long ===");

//For Loop

for (int i = 0; i < names.Length; i++)
{
    double takeHomePerHour = TakeHomePay( hoursWorked[i], hourlyRates[i], 0.18) / hoursWorked[i];
    double rateMinusTax = TakeHomePay(hoursWorked[i], hourlyRates[i], 0.18) / hoursWorked[i];
    Console.WriteLine(names[i] + ": takes home " + TakeHomePay( hoursWorked[i], hourlyRates[i], 0.18).ToString("C") + " for " + hoursWorked[i] + " hours, " + rateMinusTax.ToString("C") + " per hour, must work " + HoursToCover(tripCostPerPerson, takeHomePerHour).ToString("F2") + "hours");
    
}

//Equations

double takeHomePayPerHour = TakeHomePay(hoursWorked[2], hourlyRates[2], 0.18) / hoursWorked[2];
double totalHours = hoursWorked[0] + hoursWorked[1] + hoursWorked[2] + hoursWorked[3];
double totalPay = TakeHomePay(hoursWorked[0], hourlyRates[0], 0.18) + TakeHomePay(hoursWorked[1], hourlyRates[1], 0.18) + TakeHomePay(hoursWorked[2], hourlyRates[2], 0.18) + TakeHomePay(hoursWorked[3], hourlyRates[3], 0.18);

//Write Equation Outcomes

Console.WriteLine("");
Console.WriteLine("Total hours worked: " + totalHours);
Console.WriteLine("Total take home pay: " + totalPay.ToString("C"));
Console.WriteLine("Longest anyone must work: " + HoursToCover(tripCostPerPerson, takeHomePayPerHour).ToString("F2"));

//Methods

static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}
static double TakeHomePay(double hoursWorked, double hourlyRates, double taxRate)
{
    double grossPay = hoursWorked * hourlyRates;
    double taxWithheld = grossPay * taxRate;
    return grossPay - taxWithheld;
    
}
static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}