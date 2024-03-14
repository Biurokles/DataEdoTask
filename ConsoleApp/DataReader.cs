﻿namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataReader
    {
        IEnumerable<ImportedObject> ImportedObjects;

        public void ImportAndPrintData(string fileToImport)
        {
            ImportedObjects = new List<ImportedObject>() { new ImportedObject() };
            var streamReader = new StreamReader(fileToImport);

            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                var values = line.Split(';');
                var importedObject = new ImportedObject
                {
                    Type =  values[0].Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToUpper(),
                    Name = values.Length >= 2 ? values[1].Trim().Replace(" ", "").Replace(Environment.NewLine, "") : " ",
                    Schema = values.Length >= 3 ? values[2].Trim().Replace(" ", "").Replace(Environment.NewLine, ""): " ",
                    ParentName = values.Length >= 4 ? values[3].Trim().Replace(" ", "").Replace(Environment.NewLine, ""): " ",
                    ParentType = values.Length >= 5 ? values[4].Trim().Replace(" ", "").Replace(Environment.NewLine, ""): " ",
                    DataType = values.Length >= 6 ? values[5] : " ",
                    IsNullable = values.Length >= 7 ? values[6] : " ",
                };
                ((List<ImportedObject>)ImportedObjects).Add(importedObject);
            }

            for (int i = 0; i < ImportedObjects.Count(); i++)
            {
                var importedObject = ImportedObjects.ToArray()[i];
                foreach (var impObj in ImportedObjects)
                {
                    if (impObj.ParentType == importedObject.Type)
                    {
                        if (impObj.ParentName == importedObject.Name)
                        {
                            importedObject.NumberOfChildren = 1 + importedObject.NumberOfChildren;
                        }
                    }
                }
            }
            
            foreach (var database in ImportedObjects)
            {

                if (database.Type == "DATABASE")
                {
                    Console.WriteLine($"Database '{database.Name}' ({database.NumberOfChildren} tables)");
                    if (database.ParentType.ToUpper() == database.Type && database.ParentName == database.Name)
                    {
                        Console.WriteLine($"\tTable '{database.Schema}.{database.Name}' ({database.NumberOfChildren} columns)");
                        // print all table's columns
                        foreach (var column in ImportedObjects)
                        {
                            if (column.ParentType.ToUpper() == database.Type && column.ParentName == database.Name)
                            {
                                Console.WriteLine($"\t\tColumn '{column.Name}' with {column.DataType} data type {(column.IsNullable == "1" ? "accepts nulls" : "with no nulls")}");
                            }
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
    class ImportedObject : ImportedObjectBaseClass
    {
        public string Name { get; set; }
        public string Schema;

        public string ParentName;
        public string ParentType { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }

        public double NumberOfChildren;
    }
    class ImportedObjectBaseClass
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
