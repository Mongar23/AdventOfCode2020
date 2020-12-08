using System.Collections.Generic;
using AdventOfCode.Tools;
using System.IO;
using System;

namespace AdventOfCode.Days
{
    public class DayEight : Day
    {
        private string[] data;

        public override void Initialize()
        {
            Debug.Info("----------------Initializing day eight...");

            data = File.ReadAllLines(@".\Days\Data\DayEight.txt");
            // data = File.ReadAllLines(@".\Days\Tests\DayEight_Test.txt");

            StarOne();
            StarTwo();
        }

        protected override void StarOne()
        {
            int accumulator = 0;
            List<int> vistitedOperationsIndex = new List<int>();

            for (int i = 0; i < data.Length;)
            {
                if (vistitedOperationsIndex.Contains(i))
                {
                    Console.WriteLine($"STAR ONE: Awnser: {accumulator}");
                    return;
                }

                string[] operation = data[i].Split(' ');
                vistitedOperationsIndex.Add(i);

                switch (operation[0].Trim())
                {
                    case "nop":
                        i++;
                        break;
                    case "acc":
                        accumulator += int.Parse(operation[1].Trim());
                        i++;
                        break;
                    case "jmp":
                        i += int.Parse(operation[1].Trim());
                        break;
                    default:
                        Debug.Error($"{operation[0].Trim()} is not a supported value");
                        break;
                }
            }
        }

        protected override void StarTwo()
        {
            int accumulator = 0;

            for (int i = 0; i < data.Length; i++)
            {
                string[] dataCopy = (string[])data.Clone();
                string substring = data[i].Substring(0, 3);

                if (substring == "acc") continue;

                dataCopy[i] = substring == "jmp" ? dataCopy[i].Replace("jmp", "nop") : dataCopy[i].Replace("nop", "jmp");

                if (rightReplacement(dataCopy))
                {
                    for (int j = 0; j < dataCopy.Length;)
                    {
                        string[] operation = dataCopy[j].Split(' ');

                        switch (operation[0].Trim())
                        {
                            case "nop":
                                j++;
                                break;
                            case "acc":
                                accumulator += int.Parse(operation[1].Trim());
                                j++;
                                break;
                            case "jmp":
                                j += int.Parse(operation[1].Trim());
                                break;
                            default:
                                Debug.Error($"{operation[0].Trim()} is not a supported value");
                                break;
                        }
                    }

                    Console.WriteLine($"STAR TWO: Awnser: {accumulator}");
                    return;
                }
            }

            bool rightReplacement(string[] testProgram)
            {
                List<int> checkedOperations = new List<int>();

                for (int i = 0; i < testProgram.Length;)
                {
                    if (checkedOperations.Contains(i)) return false;

                    string[] operation = testProgram[i].Split(' ');
                    checkedOperations.Add(i);

                    switch (operation[0].Trim())
                    {
                        case "nop":
                            i++;
                            break;
                        case "acc":
                            i++;
                            break;
                        case "jmp":
                            i += int.Parse(operation[1].Trim());
                            break;
                        default:
                            Debug.Error($"{operation[0].Trim()} is not a supported value");
                            break;
                    }
                }

                return true;
            }
        }
    }
}