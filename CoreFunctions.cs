﻿public static class CoreFunctions
{
    public static List<string> Reader()
    {

        var lines = new List<string>();

        string? line;
        do
        {
            line = Console.ReadLine();

            if (line.ToLower() != "end")
            {
                lines.Add(line);
            }

        } while (line.ToLower() != "end");

        return lines;
    }
}
    public class LCM {

        private List<long> set_of_numbers = [];
        private List<long> arg_copy = []; // arrays are passed by reference; make a copy.
        private List<long> all_factors = []; // factors common to our set_of_numbers

        private long index; // index longo array common_factors
        private bool state_check; // variable to keep state
        private long calc_result;

        public LCM(List<long> group)
        {
            //iterate through and retrieve members
            foreach (long number in group)
            {
                set_of_numbers.Add(number);
                arg_copy.Add(number);
            }

            set_of_numbers.Sort();
            set_of_numbers.Reverse();

            state_check = false;
            calc_result = 1;
        }

        /**
         * Our function checks 'set_of_numbers'; If it finds a factor common to all
         * for it, it records this factor; then divides 'set_of_numbers' by the
         * common factor found and makes this the new 'set_of_numbers'. It continues
         * recursively until all common factors are found.
         *
         */
        private long findLCMFactors()
        {
            for (int i = 0; i < set_of_numbers.Count; i++)
            {
                arg_copy[i] = set_of_numbers[i];
            }
            // STEP 1:
            arg_copy.Sort();
            arg_copy.Reverse();

            while (index <= arg_copy[0])
            {
                state_check = false;
                for (int j = 0; j < set_of_numbers.Count; j++)
                {
                    if (set_of_numbers[j] != 1 && (set_of_numbers[j] % index) == 0)
                    {
                        // STEP 3:
                        set_of_numbers[j] /= index;
                        if (state_check == false)
                        {
                            all_factors.Add(index);
                        }
                        state_check = true;
                    }
                }
                // STEP 4:
                if (state_check == true)
                {
                    return findLCMFactors();
                }
                index++;
            }

            return 0;
        }

        /**
         * Just calls out and collects the prepared factors.
         * @return - long value;
         */
        public long getLCM()
        {
            // STEP 2:
            index = 2;
            findLCMFactors();

            //iterate through and retrieve members
            foreach (long factor in all_factors)
            {
                calc_result *= factor;
            }

            return calc_result;
        }
    }




