using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DisplayStudent
{
    public string FullName { get; set; }

    public DisplayStudent(string firstName, string lastName, string DateOfBirth)
    {
        FullName = $"{firstName} {lastName} \t {DateOfBirth}";
    }

    public override string ToString()
    {
        return FullName;
    }
}

