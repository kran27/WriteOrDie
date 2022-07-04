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
