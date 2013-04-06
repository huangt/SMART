using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
using System.Collections.Generic;

namespace SMART.Generators
{
	public class YahooDataGenerator : MarketDataGenerator, IMarketDataGenerator
	{
		public YahooDataGenerator ()
			: base()
		{
		}

		#region IMarketDataGenerator implementation
		
		/// <summary>
		/// Generates a bear market
		/// </summary>
		public override IEnumerable<Price> Generate ()
		{
			this.dirCSV = "/Users/Tong/Documents/workspace/SMART/src/";
			this.fileNevCSV ="SPY.csv";
//			DataSet ds = loadCVS(-1);
			DataTable table = ParseCSV("/Users/Tong/Documents/workspace/SMART/src/SPY.csv");
//			DataTable table = ds.Tables[0];
			foreach (DataRow row in table.Rows)
			{
				foreach(object item in row.ItemArray) 
				{
					if (item is int)
					{
						Console.WriteLine("Int: {0}", item);
					}
					else if (item is string)
					{
						Console.WriteLine("String: {0}", item);
					}
					else if (item is DateTime)
					{
						Console.WriteLine("DateTime: {0}", item);
					}
				}
				yield return new Price();
				Ticks++;
			}
		}
		
		#endregion

		private string dirCSV;
		private string fileNevCSV;
		
		public string FileNevCSV 
		{
			get {return fileNevCSV;}
			set {fileNevCSV = value;}
		}

		public string DirCSV
		{
			get { return dirCSV; }
			set { dirCSV = value; }
		}

		public static DataTable ParseCSV(string path)
		{
			if (!File.Exists(path))
				return null;
			else 
				Console.WriteLine("File exist!");
			string full = Path.GetFullPath(path);
			string file = Path.GetFileName(full);
			string dir = Path.GetDirectoryName(full);
			
			//create the "database" connection string 
			string connString = "Provider=Microsoft.Jet.OLEDB.4.0;"
				+ "Data Source=\"" + dir + "\\\";"
					+ "Extended Properties=\"text;HDR=No;FMT=Delimited\"";
			
			//create the database query
			string query = "SELECT * FROM " + file;
			
			//create a DataTable to hold the query results
			DataTable dTable = new DataTable();
			
			//create an OleDbDataAdapter to execute the query
			OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connString);
			
			try
			{
				//fill the DataTable
				dAdapter.Fill(dTable);
			}
			catch (InvalidOperationException /*e*/)
			{ }
			
			dAdapter.Dispose();
			
			return dTable;
		}

		public DataSet loadCVS(int noofrows)
		{
			DataSet ds = new DataSet();
			try
			{
				// Creates and opens an ODBC connection
				string strConnString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + this.dirCSV.Trim() +
					";Extensions=asc,csv,tab,txt;Persist Security Info=False";
				string sql_select;
				OdbcConnection conn;
				conn = new OdbcConnection(strConnString.Trim());
				conn.Open();
				
				//Creates the select command text
				if (noofrows == -1)
				{
					sql_select = "select * from [" + this.FileNevCSV.Trim() + "]";
				}
				else
				{
					sql_select = "select top " + noofrows + " * from [" + this.FileNevCSV.Trim() + "]";
				}
				//Creates the data adapter
				OdbcDataAdapter obj_oledb_da = new OdbcDataAdapter(sql_select, conn);
				
				//Fills dataset with the records from CSV file
				obj_oledb_da.Fill(ds, "csv");
				
				//closes the connection
				conn.Close();
			}
			catch (Exception e) //Error
			{
			}
			return ds;
		}
	}
}

