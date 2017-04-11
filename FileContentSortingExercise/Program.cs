using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileContentSortingExercise.Model;
using FileContentSortingExercise.Service;

namespace FileContentSortingExercise
{
    public class Program
    {
        private const string DefaultFileInput = "data.csv";
        private const string DefaultFileOutput1 = "frequency_and_alphabetic.txt";
        private const string DefaultFileOutput2 = "by_streetname.txt";

        public static void Main(string[] args)
        {
            var inputPath = ArgsUtil.GetArgument(args, 0, DefaultFileInput);
            var firstOutputPath = ArgsUtil.GetArgument(args, 1, DefaultFileOutput1);
            var secondOutputPath = ArgsUtil.GetArgument(args, 2, DefaultFileOutput2);

            var allLines = File.ReadAllLines(inputPath);

            var contentExtractor = new ContentExtractor();

            var extracted = contentExtractor.Extract(allLines);
            var output = new OutputGenerator(extracted);

            File.WriteAllLines(firstOutputPath, output.GetFrequencyWithAlphabeticLines());
            Console.WriteLine("Created: " + firstOutputPath);

            File.WriteAllLines(secondOutputPath, output.GetByStreetNameLines());
            Console.WriteLine("Created: " + secondOutputPath);
        }
    }
}
