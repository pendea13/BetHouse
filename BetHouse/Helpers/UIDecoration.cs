using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Helpers
{
    class UIDecoration
    {
        private static int lineLenght = 160;


        /// <summary>
        /// Title formating
        /// </summary>
        /// <param name="title">Title text</param>
        /// <param name="emptyRows">Number of empty rows following the title</param>
        /// <param name="color">Title color</param>
        public static void Title(string title, int emptyRows = 0, ConsoleColor color = ConsoleColor.Green)
        {
            string displayString = string.Empty;

            displayString += title;
            displayString += "  ";
            int length = lineLenght - displayString.Length;
            displayString += new string('=', length);

            Console.ForegroundColor = color;

            Console.WriteLine("");

            Console.WriteLine(displayString);

            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < emptyRows; i++)
            {
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Simple list witouth the pharsing, prefixes the list items with '#' by default
        /// </summary>
        /// <param name="listItems"></param>
        public static void List(IEnumerable<string> listItems, string prefix = "#")
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            foreach (string item in listItems)
            {
                Console.WriteLine($"{prefix} {item}");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
        /// <summary>
        ///  UI Menu: Displays the provided list and adds prefixes to it
        /// </summary>
        /// <param name="menuItems">List of options</param>
        /// <param name="errorMessage">Error message that the user will see if pharsing fails</param>
        /// <param name="acceptedMin">Minimal accepted value from pharsing, (Menu index starts from one)</param>
        /// <param name="acceptedMax">Maximum accepted value from pharsing</param>
        /// <param name="selection">Successfuly pharsed value (Out parameter)</param>
        /// <returns></returns>
        public static bool Menu(IEnumerable<string> menuItems, string errorMessage, int acceptedMin, int acceptedMax, out int selection)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            string _answer = string.Empty;
            bool isPharsed = false;

            int menuIndex = 1;

            foreach (string item in menuItems)
            {
                Console.WriteLine($"=> {menuIndex}. {item}");
                menuIndex++;
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            _answer = Console.ReadLine();

            isPharsed = int.TryParse(_answer, out selection);

            if (!isPharsed || selection < acceptedMin || selection > acceptedMax)
            {
                isPharsed = false;
                Error(errorMessage);
            }

            return isPharsed;
        }

        /// <summary>
        /// Question with error message and pharsing, will return fals if it faild and true if pharsing was successful.
        /// </summary>
        /// <param name="question">Text to display as question</param>
        /// <param name="errormessage">Error message on failed pharsing</param>
        /// <param name="answer">Out parameter the pharsed value (Decimal)</param>
        /// <returns></returns>
        public static bool Question(string question, string errormessage, out decimal answer)
        {
            Dialog(question);

            string s = Console.ReadLine();

            bool b = decimal.TryParse(s, out answer);

            if (!b)
                Error(errormessage);

            return b;
        }

        /// <summary>
        /// Question with error message and pharsing, will return false if it faild or value is bigger then provided maxValue and true if pharsing was successful.
        /// </summary>
        /// <param name="question">Text to display as question</param>
        /// <param name="errormessage">Error message on failed pharsing</param>
        /// <param name="maxAcceptedValue">Maximum Accepted value (Decimal)</param>
        /// <param name="answer">Out parameter the pharsed value (Decimal)</param>
        /// <returns></returns>
        //public static bool Question(string question, string errormessage, decimal maxAcceptedValue, out decimal answer)
        //{
        //    Dialog(question);

        //    string s = Console.ReadLine();

            //bool b = decimal.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out answer);

        //    if (!b || answer > maxAcceptedValue || answer < 0)
        //        Error(errormessage);

        //    return b;
        //}

        /// <summary>
        /// Question with error message and pharsing, will return fals if it faild and true if pharsing was successful.
        /// </summary>
        /// <param name="question">Text to display as question</param>
        /// <param name="errormessage">Error message on failed pharsing</param>
        /// <param name="answer">Out parameter the pharsed value (Int)</param>
        /// <returns></returns>
        public static bool Question(string question, string errormessage, out int answer)
        {
            Dialog(question);

            string s = Console.ReadLine();

            bool b = int.TryParse(s, out answer);

            if (!b)
                Error(errormessage);

            return b;
        }

        /// <summary>
        /// Question with string answer, and two options, supposed to help with yes/no questions
        /// </summary>
        /// <param name="question"></param>
        /// <param name="errorMessage"></param>
        /// <param name="optionOne"></param>
        /// <param name="optionTwo"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public static bool Question(string question, string errorMessage, string optionOne, string optionTwo, out string answer)
        {
            Dialog(question);

            string s = Console.ReadLine();

            if (s.ToLower() == optionOne || s.ToLower() == optionTwo)
            {
                answer = s;

                return true;
            }
            else
            {
                answer = null;
                return false;
            }


        }


        public static void Error(string errorMessage, int emptyRows = 0, ConsoleColor color = ConsoleColor.Red)
        {
            string displayString = string.Empty;

            displayString += errorMessage;
            displayString += "  ";
            int length = lineLenght - displayString.Length;

            displayString += new string('x', length);

            Console.ForegroundColor = color;
            Console.WriteLine("");
            Console.WriteLine(displayString);

            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < emptyRows; i++)
            {
                Console.WriteLine("");
            }
        }

        public static void Warrning(string errorMessage, int emptyRows = 0, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            string displayString = string.Empty;

            displayString += errorMessage;
            displayString += "  ";
            int length = lineLenght - displayString.Length;

            displayString += new string('=', length);

            Console.ForegroundColor = color;

            Console.WriteLine(displayString);

            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < emptyRows; i++)
            {
                Console.WriteLine("");
            }
        }
        /// <summary>
        /// Simple message to the user 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void Dialog(string message, ConsoleColor color = ConsoleColor.DarkMagenta)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
