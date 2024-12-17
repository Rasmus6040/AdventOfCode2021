namespace AdventOfCode2024._17_December;

public class Exercise1
{
    private readonly string[] _puzzleInput = PuzzleInput.Get();

    public long GetResult()
    {
        int registerA = int.Parse(_puzzleInput[0].Split(": ").Last());
        int registerB = int.Parse(_puzzleInput[1].Split(": ").Last());
        int registerC = int.Parse(_puzzleInput[2].Split(": ").Last());
        List<int> program = _puzzleInput[4].Split(": ").Last().Split(',').Select(int.Parse).ToList();

        List<string> output = [];
        for (var i = 0; i < program.Count; i+=2)
        {
            var curr = program[i];
            var operand  = program[i + 1];
            switch (curr)
            {
                case 0:
                    //The adv instruction performs division.
                    //The numerator is the value in the A register.
                    var numerator = (double)registerA;
                    //The denominator is found by raising 2 to the power of the instruction's combo operand.
                    var denominator = Math.Pow(2, GetCombo(operand));
                    //The result of the division operation is truncated to an integer and then written to the A register.
                    registerA = (int)Math.Floor(numerator / denominator);
                    break;
                case 1:
                    //The bxl instruction calculates the bitwise XOR
                    //register B and the instruction's literal operand, then stores the result in register B.
                    registerB ^= operand;
                    break;
                case 2:
                    //The bst instruction calculates the value of its
                    //combo operand modulo 8 (thereby keeping only its lowest 3 bits),
                    registerB = GetCombo(operand) % 8;
                    //then writes that value to the B register.
                    break;
                case 3:
                    //The jnz instruction does nothing if
                    //the A register is 0.
                    if (registerA == 0) break;
                    //However, if the A register is not zero, it jumps by
                    //setting the instruction pointer to the value of its literal operand;
                    //if this instruction jumps, the instruction pointer is not increased by 2 after this instruction.
                    i = operand - 2;
                    break;
                case 4:
                    // The bxc instruction calculates the bitwise XOR of register B and register C,
                    // then stores the result in register B.
                    // (For legacy reasons, this instruction reads an operand but ignores it.)
                    registerB ^= registerC;
                    break;
                case 5:
                    //The out instruction calculates the value of its combo operand modulo 8,
                    //then outputs that value.
                    //(If a program outputs multiple values, they are separated by commas.)
                    output.Add((GetCombo(operand) % 8) + "");
                    Console.WriteLine(GetCombo(operand) % 8);
                    break;
                case 6:
                    //The bdv instruction works exactly like the adv instruction
                    //except that the result is stored in the B register.
                    //(The numerator is still read from the A register.)
                    numerator = registerA;
                    //The denominator is found by raising 2 to the power of the instruction's combo operand.
                    denominator = Math.Pow(2, GetCombo(operand));
                    //The result of the division operation is truncated to an integer and then written to the A register.
                    registerB = (int)Math.Floor(numerator / denominator);
                    break;
                case 7:
                    //The cdv instruction works exactly like the adv instruction except
                    //that the result is stored in the C register.
                    //(The numerator is still read from the A register.)
                    numerator = registerA;
                    //The denominator is found by raising 2 to the power of the instruction's combo operand.
                    denominator = Math.Pow(2, GetCombo(operand));
                    //The result of the division operation is truncated to an integer and then written to the A register.
                    registerC = (int)Math.Floor(numerator / denominator);
                    break;
            }
        }
        Console.WriteLine(string.Join(", ", output));
        return 0;
        
        int GetCombo(int i1)
        {
            return i1 switch
            {
                0 or 1 or 2 or 3 => i1,
                4 => registerA,
                5 => registerB,
                6 => registerC,
                _ => throw new InvalidDataException()
            };
        }
    }
}
