# What?

You'll know, if you know.

## How?

Currently all the magic is happening in one class/file that is a real mess: [`Form1.cs`](WriteOrDie/Form1.cs). Half of the code is auto-generated from Visual Studio, by Windows Forms Designer.

### TODO:

- Rename all auto-generated variables in [`Form1.Designer.cs`](WriteOrDie/Form1.Designer.cs) in a way that it still works in VS 2022 Designer
- Rename all auto-generated methods in [`Form1.cs`](WriteOrDie/Form1.cs) to be consistent with Form1.Designer.cs
- Visuals need to be reworked
- Add more try-catch clauses
- Split the code a bit
- Add documentation
- Fix bugs

### Bugs

- You can cheat by setting up an autoclicker to click on either of the buttons

### Okay I wanna help, what now?

0. Download and install [Visual Studio 2022](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022). Make sure you selected `.NET desktop development` workload for installation.
1. Clone this repository
2. Make your changes.
3. Submit PR.

## Features

It silently makes a backup file of the text you just wrote each time you press the stop button, but only then.

## Who?

#the-patio
