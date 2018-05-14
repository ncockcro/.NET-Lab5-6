/*
 * Written by: Nicholas Cockcroft
 * Date: February 15, 2018
 * Course: .NET Environment
 * Assignemnt: Lab 5 & 6
 * 
 * Description: Create a time class, Time2, which keeps time as a single integer. 
 * Time2 should supply the same functionality as Time1. Also supply properties to get
 * and set the hours, minutes, and seconds. Also for lab 6, modify this class so that
 * the class will throw an exception if an illegal time is specified. 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5and6
{
    class Time2Test
    {
        static void Main(string[] args)
        {
            Time2 time = new Time2();  // calls Time1 constructor
            string output;

            // assign string representation of time to output
            output = "Initial universal time is: " +
               time.ToUniversalString() +
               "\nInitial standard time is: " +
               time.ToStandardString();

            // attempt valid time settings
            time.SetTime(14, 22, 18);

            // append new string representations of time to output
            output += "\n\nUniversal time after SetTime is: " +
               time.ToUniversalString() +
               "\nStandard time after SetTime is: " +
               time.ToStandardString();


            // ------- Testing code for the properties. ---------
                time.SetTime(10, 45, 55);

            // Testing the hour, minute, second properties for getting time
            int hour1 = time.Hour;
            int min1 = time.Minute;
            int sec1 = time.Second;

            // Showing the getting properties functionality
            output += "\n\nTesting the properties of getting time: " +
               "\nHour: " + hour1 +
               "\nMinute: " + min1 +
               "\nSecond: " + sec1;

            // Testing the hour, minute, second properties for setting time
            // along with a try-catch block to make sure no invalid settings were made
            try
            {
                time.Hour = 12;
                time.Minute = 23;
                time.Second = 14;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            // Testing the setting of minute after 12:23:14 was the set time
            time.Minute = 20;

            // Showing the setting properties fuctionality
            output += "\n\nTesting the properties of setting time: " +
               "\nUniversal time: " + time.ToUniversalString() +
               "\nStandard time: " + time.ToStandardString();


            // Testing time with one more example to make sure it still outputs
            // the correct time even with a previous time already being set
            time.Hour = 14;
            time.Minute = 54;
            time.Second = 34;

            output += "\n\nTesting time after already having it set: " +
               "\nUniversal time: " + time.ToUniversalString() +
               "\nStandard time: " + time.ToStandardString();

            MessageBox.Show(output, "Testing Class Time1");
        }
    }
}
