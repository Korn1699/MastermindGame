Console.WriteLine("Welcome to the game!");

var random = new Random();
var secretCombination = random.Next(1000, 10000);

var attempt = 0;
var isCorrect = false;

while (!isCorrect && attempt < 10)
{
	Console.WriteLine("Enter your 4 digit combination:");
	var input = Console.ReadLine();

	if (!string.IsNullOrEmpty(input) && (input.Length == 4 && int.TryParse(input, out _)))
	{
		var userCombination = int.Parse(input);
		if (userCombination is >= 1000 and <= 9999)
		{
			var correctPlacement = 0;
			var correctNumber = 0;

			if (userCombination == secretCombination)
			{
				Console.WriteLine("Congratulations! You found the secret combination!");
				isCorrect = true;
			}
			else
			{
				for (var x = 0; x < 4; x++)
				{
					if (userCombination.ToString()[x] == secretCombination.ToString()[x])
					{
						correctPlacement++;
					}
					else if (secretCombination.ToString().Contains(userCombination.ToString()[x]))
					{
						correctNumber++;
					}
				}

				var feedback = string.Concat(Enumerable.Repeat("+", correctPlacement)) +
				               string.Concat(Enumerable.Repeat("-", correctNumber));
				Console.WriteLine(feedback);
			}
		}
		else
		{
			Console.WriteLine("Invalid input. Please enter a number from 1000 through 9999");
		}
	}
	else
	{
		Console.WriteLine("Invalid input. Please enter a 4 digit number.");
	}

	attempt++;
};

if (!isCorrect)
{
	Console.WriteLine("You have reached the maximum number of attempts. The secret combination was: " + secretCombination);
}