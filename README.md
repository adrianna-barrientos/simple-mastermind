# Simple Mastermind (C# Console App)

This is a small console game I built as part of a coding assessment for Quadax. It’s a basic version of the classic **Mastermind** game, written in C#.



## How it works

The computer randomly generates a 4-digit number using digits between 1 and 6 (e.g., `1234`). The player gets 10 chances to guess it.

After each guess, the game gives you hints:
- `+` for each digit that’s correct and in the right spot
- `-` for each digit that’s correct but in the wrong spot

The `+` signs always come before the `-` signs. No symbol means that digit isn’t in the answer at all.



### Example

If the secret number is `1234` and the player guesses `4233`, the output would be:

++-



## Running the project

Make sure you have [.NET 8.0 SDK](https://dotnet.microsoft.com/download) installed.

To run the project, navigate to the project folder and execute:

  dotnet run



## Notes
This was a fun little challenge! It covers:

  - Random number generation

  - Basic input validation

  - Comparing digits by position

  - Simple console feedback and loops

If I had more time, I’d probably add some extra touches like replayability, stats, or more flexible difficulty settings.

Thanks for checking it out!
