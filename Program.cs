using AoC24;

int day = 14;
ISolver solver;

if (day == 1)
{
    solver = new One();
    solver.solve();
}
else if (day == 2)
{
    solver = new Two();
    solver.solve();
}
else if (day == 3)
{
    solver = new Three();
    solver.solveSecondPart();
}
else if (day == 11)
{
    solver = new Eleven();
    //solver.solve();
    ((Eleven)solver).solveWithHelpFromReddit();
}
else if (day == 13)
{
    solver = new Thirtheen();
    solver.solve();
}
else if (day == 14)
{
    solver = new Fourteen();
    solver.solve();
}
else if (day == 0)
{
    var test = new Test();
    test.Run();
}
