using HtmlPageAnalyzer.Commands;
using HtmlPageAnalyzer.Core;
using HtmlPageAnalyzer.Core.DataInterfaces;
using HtmlPageAnalyzer.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HtmlPageAnalyzer
{
    /// <summary>
    /// Menu item storing command and it's hotkey to execute
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Keyboard key associated with item
        /// </summary>
        internal ConsoleKey CommandKey { get; set; }
        /// <summary>
        /// Command associated with item
        /// </summary>
        public ICommand Command { get; private set; }
        /// <summary>
        /// Menu item text
        /// </summary>
        internal string PromptKey { get; private set; }

        public MenuItem(ConsoleKey commandKey, ICommand command, string promptKey)
        {
            CommandKey = commandKey;
            Command = command;
            PromptKey = promptKey;
        }
    }

    /// <summary>
    /// Represents user menu
    /// </summary>
    public class Menu 
    {
        private List<MenuItem> Items { get; }

        public Menu()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            ITextAnalysisDao dao = new TextAnalysisDao(connectionString);
            Items = new List<MenuItem>
            {
                new MenuItem(ConsoleKey.D1, new AnalyzePageCommand(new WebPageLoader(), new HtmlParser(), dao), "Посчитать количество уникальных слов на html-странице"),
                new MenuItem(ConsoleKey.D2, new PrintAllStatisticsCommand(dao), "Вывести предыдущие результаты подсчета частоты нахождения слов"),
                new MenuItem(ConsoleKey.Escape, new ExitCommand(), "Выйти из программы")
            };
        }

        /// <summary>
        /// Prints all menu items to console
        /// </summary>
        public void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите опцию:");
            foreach (MenuItem item in Items)
            {
                Console.WriteLine($"{item.CommandKey} - {item.PromptKey}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Return the command to execute according to user input
        /// </summary>
        /// <returns></returns>
        public ICommand GetNextCommand()
        {
            bool exitLoop = false;

            ICommand command = new ExitCommand();
            do
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                foreach (MenuItem item in Items)
                {
                    if (item.CommandKey == cki.Key)
                    {
                        exitLoop = true;
                        command = item.Command;
                    }
                }
            } while (!exitLoop);
            return command;
        }
    }
}
