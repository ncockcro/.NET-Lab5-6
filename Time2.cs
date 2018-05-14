/*
 * Written by: Nicholas Cockcroft
 * Date: February 15, 2018
 * Course: .NET Environment
 * Assignemnt: Lab 5 & 6
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
    class Time2
    {
        //private int hour;    // 0 -23
        //private int minute;  // 0-59
        //private int second;  // 0-59
        private int m_time = 0; // holds hours, minutes, and seconds
        private int resetTime; // used for resetting the time if a new value is passed in

        // Time1 constructor initializes instance variables to 
        // zero to set default time to midnight
        public Time2()
        {
            SetTime(0, 0, 0);
        }

        // Set new time value in 24-hour format. Perform validity
        // checks on the data. Set invalid values to zero.
        public void SetTime(
           int hourValue, int minuteValue, int secondValue)
        {
            // Reset m_time when it is called.
            m_time = 0;

            // If statements checking to make sure invalid inputs are handled
            // and throw an exception which will be caught when the method is finished

            if (hourValue < 0 || hourValue >= 24)
            {
                hourValue = 0;
                throw new Exception("Hour is an invalid number, exception thrown.");
            }
            else if (minuteValue < 0 || minuteValue >= 60)
            {
                minuteValue = 0;
                throw new Exception("Minute is an invalid number, exception thrown.");
            }
            else if (secondValue < 0 || secondValue >= 60)
            {
                secondValue = 0;
                throw new Exception("Second is an invalid number, exception thrown.");
            }
            // If we get passed all of the exception handling, then we can treat it as normal inputs
            else
            {
                m_time += 3600 * hourValue;
                m_time += 60 * minuteValue;
                m_time += secondValue;
            }

        } // end method SetTime

        // convert time to universal-time (24 hour) format string
        public string ToUniversalString()
        {

            return String.Format(
               "{0:D2}:{1:D2}:{2:D2}", m_time / 3600, (m_time % 3600) / 60, m_time % 60);
        }

        // convert time to standard-time (12 hour) format string
        public string ToStandardString()
        {
            return String.Format("{0}:{1:D2}:{2:D2} {3}",
               (((m_time / 3600) == 12 || (m_time / 3600) == 0) ? 12 : (m_time / 3600) % 12),
               (m_time % 3600) / 60, m_time % 60, ((m_time / 3600) < 12 ? "AM" : "PM"));
        }

        // Hour propeerty
        public int Hour
        {
            get
            {
                return m_time / 3600;
            }
            set
            {
                // If statement used resetting the time if there was a previous time set
                if ((m_time / 3600) != 0)
                {
                    resetTime = m_time / 3600;
                    m_time -= resetTime * 3600;
                }
                // Exception is thrown if the hour input is invalid
                if (value < 0 || value >= 24)
                {
                    throw new Exception("Not a valid hour, exception thrown.");
                }
                else
                {
                    m_time += 3600 * value;
                }
            }
        }
        // Minute Property
        public int Minute
        {
            get
            {
                return (m_time % 3600) / 60;
            }
            set
            {
                // If statement used resetting the time if there was a previous time set
                if ((m_time % 3600) / 60 != 0)
                {
                    resetTime = (m_time % 3600) / 60;
                    m_time -= resetTime * 60;
                }
                // Throws exception if minutes is not a valid input
                if (value < 0 || value >= 60)
                {
                    throw new Exception("Not a valid minute, exception thrown.");
                }
                else
                {
                    m_time += 60 * value;
                }
            }
        }

        // Second property
        public int Second
        {
            get
            {
                return m_time % 60;
            }
            set
            {
                // If statement used resetting the time if there was a previous time set
                if ((m_time % 60) != 0)
                {
                    resetTime = m_time % 60;
                    m_time -= resetTime;
                }
                // Throwing exception if seconds are not a normal time
                if (value < 0 || value >= 60)
                {
                    throw new Exception("Not a valid second. exception thrown.");
                }
                else
                {
                    m_time += value;
                }

            }
        }
    }
}
