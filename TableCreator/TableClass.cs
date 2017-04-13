using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TableCreator
{
    /// <summary>
    /// Lib To Create SQL Query from Class.
    /// Modified By Amit Kumar
    /// </summary>
    public class TableClass
    {
        private List<KeyValuePair<String, Type>> _fieldInfo = new List<KeyValuePair<String, Type>> ();
        private string _className = String.Empty;

        private Dictionary<Type, String> dataMapper
        {
            get
            {
                // Add the rest of your CLR Types to SQL Types mapping here
                Dictionary<Type, String> dataMapper = new Dictionary<Type, string> ();
                dataMapper.Add (typeof (int), "INT");//BIGINT
                dataMapper.Add (typeof (string), "VARCHAR(100)");
                dataMapper.Add (typeof (bool), "BIT");
                dataMapper.Add (typeof (DateTime), "DATETIME");
                dataMapper.Add (typeof (float), "FLOAT");
                dataMapper.Add (typeof (decimal), "DECIMAL(18,0)");
                dataMapper.Add (typeof (Guid), "UNIQUEIDENTIFIER");
                dataMapper.Add (typeof (double), "Money");

                return dataMapper;
            }
        }

        public List<KeyValuePair<String, Type>> Fields
        {
            get { return this._fieldInfo; }
            set { this._fieldInfo = value; }
        }

        public string ClassName
        {
            get { return this._className; }
            set { this._className = value; }
        }

        public TableClass(Type t)
        {
            this._className = t.Name;

            foreach ( PropertyInfo p in t.GetProperties () )
            {
                KeyValuePair<String, Type> field = new KeyValuePair<String, Type> (p.Name, p.PropertyType);

                this.Fields.Add (field);
            }
        }

        public string CreateTableScript()
        {
            System.Text.StringBuilder script = new StringBuilder ();

            script.AppendLine ("CREATE TABLE " + this.ClassName);
            script.AppendLine ("(");
            int x = 0;
            if ( Fields [0].Key == "ID" )
            {
                x = 1;
                script.AppendLine ("\t ID INT Not Null Primary Key Identity,");
            }
            else
                script.AppendLine ("\t ID INT Not Null Primary Key Identity,");

            
            for ( int i = x ; i < this.Fields.Count ; i++ )
            {
                KeyValuePair<String, Type> field = this.Fields [i];

                if ( dataMapper.ContainsKey (field.Value) )
                {
                    script.Append ("\t " + field.Key + " " + dataMapper [field.Value]);
                }
                else
                {
                    // Complex Type? 
                    script.Append ("\t " + field.Key + " INT");
                }

                if ( i != this.Fields.Count - 1 )
                {
                    script.Append (",");
                }

                script.Append (Environment.NewLine);
            }

            script.AppendLine (")");

            return script.ToString ();
        }
    }
}