using AoC24;

int day = 11;
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
    solver.solveSecondPart();
}
