//using System.Windows.Forms;

namespace TableCreator
{
    internal class MainProgram
    {
        //public static void CreatTable( string tableName, RichTextBox ta )
        //{
        //    private List<TableClass> tables = new List<TableClass>();

        //// Pass assembly name via argument
        //private Assembly a = Assembly.LoadFile(tableName);

        //private Type[] types = a.GetTypes();

        //    // Get Types in the assembly.
        //    foreach (Type t in types)
        //    {
        //        private TableClass tc = new TableClass(t);
        //tables.Add(tc);
        //    }

        //    // Create SQL for each table
        //    foreach (TableClass table in tables)
        //    {
        //        Console.WriteLine((ta.Text = ta.Text + "\n" + table.CreateTableScript()).TrimEnd( ));
        //        Console.WriteLine();
        //    }

        //    // Total Hacked way to find FK relationships! Too lazy to fix right now
        //    foreach (TableClass table in tables)
        //    {
        //        foreach (KeyValuePair<String, Type> field in table.Fields)
        //        {
        //            foreach (TableClass t2 in tables)
        //            {
        //                if (field.Value.Name == t2.ClassName)
        //                {
        //                    // We have a FK Relationship!
        //                    Console.WriteLine("GO");
        //                    Console.WriteLine("ALTER TABLE " + table.ClassName + " WITH NOCHECK");
        //                    Console.WriteLine("ADD CONSTRAINT FK_" + field.Key + " FOREIGN KEY (" + field.Key + ") REFERENCES " + t2.ClassName + "(ID)");
        //                    Console.WriteLine("GO");
        //                }
        //            }
        //        }
        //    }
        //}
    }
}