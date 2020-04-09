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
                int innerPadding;

                bool beforeMiddle = true;
                for (var i = 0; i <= 2 * charIndex; i++)
                {
                    var padding = new string(' ', charIndex);

                  

                    char letter = 'X';

                    if (i <= charIndex)
                    {
                        letter = (char)(65 + i);
                    }
                    else
                    {
                        letter = (char)(66 + (charIndex - i));
                    }

                    if (letter == value)
                    {
                        output[i] = $"{letter}{padding}{letter}";
                    }
                    else
                    {
                        outputHelper.WriteLine(
                            $"Padding: \"{padding}\" Letter: {letter}, i: {i}, totalLengthOfLine: {totalLengthOfLine}");
                        var secondLetter = i==0? "":$"{new string(' ', (totalLengthOfLine - 2) - (2 * outerPadding))}{letter}";
                        output[i] = $"{new string(' ', outerPadding)}{letter}{secondLetter}{new string(' ', outerPadding)}";
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
