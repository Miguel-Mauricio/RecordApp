using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record
{
    internal class RecordApp
    {


        List<Record> records = new List<Record>();
        public void Run()
        {



            bool exit = false;

            while (!exit)
            {

                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("[S]ee all records");
                Console.WriteLine("[A]dd a record");
                Console.WriteLine("[R]emove a record");
                Console.WriteLine("[E]xit");

                var userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "E":
                    case "e":
                        exit = true;
                        break;
                    case "S":
                    case "s":
                        SeeAllRecords(records);

                        break;
                    case "A":
                    case "a":
                        AddRecord();
                        break;
                    case "R":
                    case "r":
                        RemoveTodo();
                        break;


                    default:
                        Console.WriteLine("Invalid input, try again...");
                        break;
                }

            }
        }

        private void RemoveTodo()
        {
            SeeAllRecords(records); 
            Console.Write("Enter the ID of the record you want to remove: ");
            int idToRemove = Convert.ToInt32(Console.ReadLine())-1
                ;
            if (idToRemove >= 0 && idToRemove < records.Count)
            {
                records.RemoveAt(idToRemove);
                Console.WriteLine("Record removed successfully!");
                SaveRecordsToFile();
            }
            else
            {
        
                Console.WriteLine("Invalid ID. Try again.");
            }
        }

        private void AddRecord()
        {

            Console.WriteLine("What do you want to save?");
            Console.WriteLine("");
            var userInput = Console.ReadLine();

            var record = new Record(userInput);

            records.Add(record);

            var recordLines = records.Select(i => $"{i.description}");
            File.WriteAllLines("records.txt", recordLines);

            Console.WriteLine("Record saved!");
        }





        private void SeeAllRecords(List<Record> records)
        {
            if (File.Exists("records.txt")&&(records.Count==0))
            {
                var recordLines = File.ReadAllLines("records.txt");
                foreach (var line in recordLines)
                {
                    records.Add(new Record(line));
                }
            }

            if (records.Count == 0)
            {
                Console.WriteLine("No records yet");

            }

            int id = 1;
            foreach (var record in records)
            {
                Console.WriteLine($"{id} - {record.description}");
                id++;


            }


        }
        private void SaveRecordsToFile()
        {
            var recordLines = records.Select(i => i.description).ToList();
            File.WriteAllLines("records.txt", recordLines);
        }
    }
}
