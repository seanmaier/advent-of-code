# Advent-of-code-2024

Welcome to my repository for the Advent of Code 2024! 🎄✨ This project contains solutions to the daily programming puzzles, implemented in C#.

Each day's solution is organized into its own project directory, providing a clean structure for managing and running individual solutions.

# Repository Structure
```
.
├── day-1.proj/   # Solution for Day 1
├── day-2.proj/   # Solution for Day 2
├── day-3.proj/   # Solution for Day 3
...
├── README.md     # You're here!
```

# Getting Started
## Prerequisites
.NET SDK: Ensure you have the .NET SDK installed on your machine to build and run the projects.

## Running a Solution
Navigate to the desired project directory:

```
cd day-1.proj
```

Add a ``input.txt`` in the ``day-{number}\bin\Debug\net8.0``
Otherwise you will get an error, for missing a ``.txt`` file

Build and run the project:

```
dotnet run
```

# Easily adding a new day

## Purpose
Automates creating a new project for each Advent of Code day. It initializes a folder, creates a console project, adds it to the .sln file, and prepares input files.

## Usage
Run the script
```
.\AddNewDay.ps1 -DayNumber <Day>

```

## Features
- Creates a new folder: day-<Day>.
- Initializes a .NET console project.
- Adds the project to the .sln file.
- Creates Input.txt and TestInput.txt.

# Contributing
Feel free to fork this repository, experiment with alternate solutions, or optimize my implementations! Pull requests are welcome.