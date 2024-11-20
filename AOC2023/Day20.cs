namespace _AdventOfCode.AOC2023
{
    public class Day20
    {
        public long lowPulses = 1;
        public long highPulses = 0;

        public List<flipflop> flipflopList = new List<flipflop>();
        public List<conjunction>  conjunctionList = new List<conjunction>();


        public void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 20");

            long answer = 0;

            var broadcaster = new module(); ;

            foreach (string line in lines)
            {
                module module = null;

                if (line.StartsWith("broadcaster"))
                {
                    broadcaster = new module
                    {
                        id = "broadcaster",
                        targets = line.Split('>')[1].Trim().Split(',').Select(x => x.Trim()).ToArray()
                    };
                }

                if (line.StartsWith('%'))
                {
                    var ff = new flipflop
                    {
                        id = line.Split(' ')[0].Substring(1),
                        targets = line.Split('>')[1].Trim().Split(',')
                        
                    };
                    flipflopList.Add(ff);
                }

                if (line.StartsWith('&'))
                {
                    var conj = new conjunction
                    {
                        id = line.Split(' ')[0].Substring(1),
                        targets = line.Split('>')[1].Trim().Split(',').Select(x => x.Trim()).ToArray(),
                        inputs = []
                    };
                    conjunctionList.Add(conj);
                }
            }



                lowPulses += broadcaster.targets.Length;

                Process("broadcaster", false, broadcaster.targets);
            
            answer = (lowPulses*1000) * (highPulses*1000);
            

            Console.WriteLine("answer: " + answer);
        }

        //low = false,high = true
        public void Process(string sender, bool pulse,string[] targets)
        {

            foreach (var target in targets)
            {
                if (flipflopList.Any(x => x.id == target))
                {
                    if (pulse) continue;

                    var ffTarget = flipflopList.First(x => x.id == target);

                    if (ffTarget.isOn)
                    {
                        ffTarget.isOn = !ffTarget.isOn;
                        lowPulses++;
                        Process(ffTarget.id, false, ffTarget.targets);
                    }
                    else
                    {
                        ffTarget.isOn = !ffTarget.isOn;
                        highPulses++;
                        Process(ffTarget.id, true, ffTarget.targets);
                    }
                }

                if (conjunctionList.Any(x => x.id == target))
                {
                    var cjTarget = conjunctionList.First(x => x.id == target);

                    //add sender
                    if (!cjTarget.inputs.Keys.Any(k => k == sender))
                    {
                        cjTarget.inputs.Add(sender, pulse);
                    }
                    else
                    {
                        cjTarget.inputs[sender] = pulse;
                    }
                

                    if (cjTarget.inputs.All(i => i.Value))
                    {
                        lowPulses++;
                        Process(cjTarget.id, false, cjTarget.targets);
                    }
                    else
                    {
                        highPulses++;
                        Process(cjTarget.id, true, cjTarget.targets);
                    }
                }
            }
        }




        /*
         * flipflop         
         *  - high-pulse nothing happens
         *  - low-pulse
         *      - off: turn on, send high
         *      - on: torn off, send low
         *      
         *  Conjunction
         *   - low default memory
         *   - if all memory high, send low
         *   - else send high
         * */


        public class module 
        { 
            public string id { get; set; }                        
            public string[] targets { get; set; }
        }

        public class flipflop : module {
            public bool isOn { get; set; }
        }

        public class conjunction : module
        {
            //true = high, false = low
            public Dictionary<string, bool> inputs { get; set; }
        }
    }
}
