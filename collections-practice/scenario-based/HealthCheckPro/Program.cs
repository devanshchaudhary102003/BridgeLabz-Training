using System;
using HealthCheckPro.Scanner;

namespace HealthCheckPro;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----------HEALTHCHECKPRO => aPI Metadata Validator --------------");
        ApiMetadataScanner.ScanControllers();
    }
}
