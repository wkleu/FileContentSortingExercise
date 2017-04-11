using System;

namespace FileContentSortingExercise.Model
{
    public class NameWithFrequency
    {
        public NameWithFrequency(string name, int frequency)
        {
            Name = name;
            Frequency = frequency;
        }

        public string Name { get; }
        public int Frequency { get; }

        public override bool Equals(object other)
        {
            var nameWithFrequency = other as NameWithFrequency;
            return nameWithFrequency != null &&
                   Name.Equals(nameWithFrequency.Name) &&
                   Frequency.Equals(nameWithFrequency.Frequency);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Name, Frequency).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}: {Frequency}";
        }
    }
}