﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file CountryRegionCurrencyTest.cs instead.
*/

#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="CountryRegionCurrency"/> objects (entity, collection and repository).
    /// </summary>
   public partial class CountryRegionCurrencyTest
    {
    	// the CountryRegionCurrency instance used to test the repository.
		protected CountryRegionCurrency mock;
		
		// the TList<CountryRegionCurrency> instance used to test the repository.
		protected TList<CountryRegionCurrency> mockCollection;
		
		protected static TransactionManager CreateTransaction()
		{
			TransactionManager transactionManager = null;
			if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
			}			
			return transactionManager;
		}
		       
        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>        
        static public void Init_Generated()
        {		
        	System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the CountryRegionCurrency Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		static public void CleanUp_Generated()
        {   		
			System.Console.WriteLine("All Tests Completed");
			System.Console.WriteLine();
        }
    
    
		
		
		/// <summary>
		/// Selects all CountryRegionCurrency objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.CountryRegionCurrencyProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.CountryRegionCurrencyProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.CountryRegionCurrencyProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all CountryRegionCurrency children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.CountryRegionCurrencyProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.CountryRegionCurrencyProvider.DeepLoading += new EntityProviderBaseCore<CountryRegionCurrency, CountryRegionCurrencyKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.CountryRegionCurrencyProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("CountryRegionCurrency instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.CountryRegionCurrencyProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock CountryRegionCurrency entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_CountryRegionCurrency.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock CountryRegionCurrency entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_CountryRegionCurrency.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<CountryRegionCurrency>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a CountryRegionCurrency collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_CountryRegionCurrencyCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<CountryRegionCurrency> mockCollection = new TList<CountryRegionCurrency>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<CountryRegionCurrency> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a CountryRegionCurrency collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_CountryRegionCurrencyCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<CountryRegionCurrency>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<CountryRegionCurrency> mockCollection = (TList<CountryRegionCurrency>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<CountryRegionCurrency> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				
				CountryRegionCurrency entity = mock.Copy() as CountryRegionCurrency;
				entity = (CountryRegionCurrency)mock.Clone();
				Assert.IsTrue(CountryRegionCurrency.ValueEquals(entity, mock), "Clone is not working");
			}
		}
		
		/// <summary>
		/// Test Find using the Query class
		/// </summary>
		private void Step_30_TestFindByQuery_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Insert Mock Instance
				CountryRegionCurrency mock = CreateMockInstance(tm);
				bool result = DataRepository.CountryRegionCurrencyProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				CountryRegionCurrencyQuery query = new CountryRegionCurrencyQuery();
			
				query.AppendEquals(CountryRegionCurrencyColumn.CountryRegionCode, mock.CountryRegionCode.ToString());
				query.AppendEquals(CountryRegionCurrencyColumn.CurrencyCode, mock.CurrencyCode.ToString());
				query.AppendEquals(CountryRegionCurrencyColumn.ModifiedDate, mock.ModifiedDate.ToString());
				
				TList<CountryRegionCurrency> results = DataRepository.CountryRegionCurrencyProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed CountryRegionCurrency Entity with mock values.
		///</summary>
		static public CountryRegionCurrency CreateMockInstance_Generated(TransactionManager tm)
		{		
			CountryRegionCurrency mock = new CountryRegionCurrency();
						
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();
			
			//OneToOneRelationship
			CountryRegion mockCountryRegionByCountryRegionCode = CountryRegionTest.CreateMockInstance(tm);
			DataRepository.CountryRegionProvider.Insert(tm, mockCountryRegionByCountryRegionCode);
			mock.CountryRegionCode = mockCountryRegionByCountryRegionCode.CountryRegionCode;
			//OneToOneRelationship
			Currency mockCurrencyByCurrencyCode = CurrencyTest.CreateMockInstance(tm);
			DataRepository.CurrencyProvider.Insert(tm, mockCurrencyByCurrencyCode);
			mock.CurrencyCode = mockCurrencyByCurrencyCode.CurrencyCode;
		
			// create a temporary collection and add the item to it
			TList<CountryRegionCurrency> tempMockCollection = new TList<CountryRegionCurrency>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (CountryRegionCurrency)mock;
		}
		
		
		///<summary>
		///  Update the Typed CountryRegionCurrency Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, CountryRegionCurrency mock)
		{
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();
			
			//OneToOneRelationship
			CountryRegion mockCountryRegionByCountryRegionCode = CountryRegionTest.CreateMockInstance(tm);
			DataRepository.CountryRegionProvider.Insert(tm, mockCountryRegionByCountryRegionCode);
			mock.CountryRegionCode = mockCountryRegionByCountryRegionCode.CountryRegionCode;
					
			//OneToOneRelationship
			Currency mockCurrencyByCurrencyCode = CurrencyTest.CreateMockInstance(tm);
			DataRepository.CurrencyProvider.Insert(tm, mockCurrencyByCurrencyCode);
			mock.CurrencyCode = mockCurrencyByCurrencyCode.CurrencyCode;
					
		}
		#endregion
    }
}
