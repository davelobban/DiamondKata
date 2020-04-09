using System;
using Xunit.Abstractions;

namespace TestProject
{
    public class DiamondBuilder
    {
        private readonly ITestOutputHelper outputHelper;

        public DiamondBuilder(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        public string[] Build(char value)
        {
            int charIndex = (int)value;
            charIndex -= 65;

            if (charIndex == 0)
            {
                var letter = (char)(65);
                return new[] { letter.ToString() };
            }
            else
            {
                var output = new string[1 + (2 * charIndex)];// total length of line =  1 + (2 * charIndex)
                                                             //line = {padding}{letter}{middlePadding=totalLengthOfLine-2-(2*padding)}{letter}{padding}"
                                                             /*
                                                              *   22A22
                                                              *   1B1B1   
                                                              *
                                                              *
                                                              *
                                                              */
                var totalLengthOfLine = (2 * (1 + charIndex)) - 1; //a:1; B: 3; c: 5; D:7

                int outerPadding = charIndex;
                
                bool beforeMiddle = true;
                for (var i = 0; i <= 2 * charIndex; i++)
                {
                    var padding = new string(' ', charIndex);

                    char letter;
                    if (i <= charIndex)
                    {
                        letter = (char)(65 + i);
                        //outputHelper.WriteLine($"L1 letter:{letter}");
                    }
                    else
                    {
                        letter = (char)(65 + Math.Abs((2 * charIndex) - i));
                        //outputHelper.WriteLine($"L2 letter:{letter} charIndex:{charIndex}");
                    }

                    if (letter == value)
                    {
                        if (charIndex > 1)
                        {
                            padding = new string(' ', charIndex + 1);
                        }
                        //outputHelper.WriteLine($"Padding: \"{padding}\" Letter: {letter}, i: {i}, totalLengthOfLine: {totalLengthOfLine} outerPadding: {outerPadding} beforeMiddle: {beforeMiddle} secondLetter :{secondLetter }");

                        output[i] = $"{letter}{padding}{letter}";
                        outputHelper.WriteLine($"1. output[i]: ..{output[i]}..");
                    }
                    else
                    {
                        //outputHelper.WriteLine($"Padding: \"{padding}\" Letter: {letter}, i: {i}, totalLengthOfLine: {totalLengthOfLine} outerPadding: {outerPadding} beforeMiddle: {beforeMiddle}");
                        var secondPaddingLength = (totalLengthOfLine - 2) - (2 * outerPadding);
                        secondPaddingLength = secondPaddingLength < 0 ? 0 : secondPaddingLength;

                        var secondLetterCharacter = secondPaddingLength > 0 ? letter.ToString() : string.Empty;
                        var secondLetter = i == 0 ? "" : $"{new string(' ', secondPaddingLength)}{secondLetterCharacter }";

                        output[i] = $"{new string(' ', outerPadding)}{letter}{secondLetter}{new string(' ', outerPadding)}";
                        outputHelper.WriteLine($"2. output[i]: ..{output[i]}..");
                    }

                    if (beforeMiddle)
                    {
                        outerPadding--;
                    }
                    else
                    {
                        outerPadding++;
                    }

                    if (outerPadding == 0)
                    {
                        beforeMiddle = false;
                    }
                }

                return output;

            }
        }
    }
}
//value = B

// 0  A
// 1  B
// 2  null
