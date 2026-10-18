/*
Name: Evan Clark
Course: CSCI 1250, Section 201
Assignment: Lab 04, The Group Trip
Date: 10/17/26
Description: Rebuilds the trip calculator with methods and arrays so it
reports on a whole group instead of one person.
*/
using System.Runtime.CompilerServices;

const double pizzaSlices = 8;
const double taxRate = 0.07;
string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

//Part 1:

//Input for Part 1

System.Console.Write("How many miles for your trip? ");
double miles = Convert.ToDouble(Console.ReadLine());

System.Console.Write("How many miles per gallon can your car go? ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

System.Console.Write("How much is one gallon of gas? ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

//Calculations for Part 1

double fuelCost = FuelCost(miles, milesPerGallon, pricePerGallon);


//People Going is gone, account for this

System.Console.Write("How many pizzas? ");
double numberOfPizzas = Convert.ToDouble(Console.ReadLine());

System.Console.Write("Price per pizza? ");
double pricePerPizza = Convert.ToDouble(Console.ReadLine());


double pizzaCost = numberOfPizzas * pricePerPizza;
double tripTotal = pizzaCost + fuelCost;

//Print for Part 1

System.Console.WriteLine("");
System.Console.WriteLine("=== Part 1: The Trip ===");

System.Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));
System.Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));
System.Console.WriteLine("Trip cost: " + tripTotal.ToString("C"));

System.Console.WriteLine("");



//Part 2

double slicesEach = pizzaSlices / names.Length;
double costPerPerson = tripTotal / names.Length;

System.Console.WriteLine("");
System.Console.WriteLine("=== Part 2: The Group ===");

System.Console.WriteLine("People going: " + names.Length);
System.Console.WriteLine("Slices each: " + slicesEach);
System.Console.WriteLine("Cost per person: " + costPerPerson);


//Part 3
System.Console.WriteLine("");
System.Console.WriteLine("=== Part 3: Who Works How Long ===");

double totalHours = 0;
double totalHomed = 0;
double longest = 0;

for (int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double takeHomePerHour = takeHomePay / hoursWorked[i];
    double hoursNeeded = HoursToCover(costPerPerson, takeHomePerHour);

    totalHours = totalHours + hoursWorked[i];
    totalHomed = totalHomed + takeHomePay;
    longest = Math.Max(longest, hoursNeeded);

    System.Console.WriteLine(names[i] + ": takes home " + takeHomePay.ToString("C") + " for " + hoursWorked[i] + " hours, " + takeHomePerHour.ToString("C") + " per hour, must work " + hoursNeeded.ToString("F2") + " hours");

}
System.Console.WriteLine("Total hours worked: " + totalHours.ToString("F0"));
System.Console.WriteLine("Total take home pay: " + totalHomed.ToString("C"));
System.Console.WriteLine("Longest anyone must work: " + longest.ToString("F2"));


static double FuelCost(double miles, double milesPerGallon, double priceperGallon)
{
    double gallons =  miles/milesPerGallon;
    return gallons * priceperGallon;

}

static double TakeHomePay(double hours, double payRate, double TaxRate)
{
    double payEarned = hours * payRate;
    double taxAmount = payEarned * TaxRate;
    return payEarned - taxAmount;
}
static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}