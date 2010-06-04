﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file AddressTypeTest.cs instead.
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
    /// Provides tests for the and <see cref="AddressType"/> objects (entity, collection and repository).
    /// </summary>
   public partial class AddressTypeTest
    {
    	// the AddressType instance used to test the repository.
		protected AddressType mock;
		
		// the TList<AddressType> instance used to test the repository.
		protected TList<AddressType> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the AddressType Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock AddressType entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.AddressTypeProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.AddressTypeProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all AddressType objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.AddressTypeProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.AddressTypeProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.AddressTypeProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all AddressType children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.AddressTypeProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.AddressTypeProvider.DeepLoading += new EntityProviderBaseCore<AddressType, AddressTypeKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.AddressTypeProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("AddressType instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.AddressTypeProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock AddressType entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				AddressType mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.AddressTypeProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.AddressTypeProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.AddressTypeProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock AddressType entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (AddressType)CreateMockInstance(tm);
				DataRepository.AddressTypeProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.AddressTypeProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.AddressTypeProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock AddressType entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_AddressType.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock AddressType entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_AddressType.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<AddressType>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a AddressType collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_AddressTypeCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<AddressType> mockCollection = new TList<AddressType>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<AddressType> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a AddressType collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_AddressTypeCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<AddressType>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<AddressType> mockCollection = (TList<AddressType>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<AddressType> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				AddressType entity = CreateMockInstance(tm);
				bool result = DataRepository.AddressTypeProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				AddressType entity = CreateMockInstance(tm);
				bool result = DataRepository.AddressTypeProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				AddressType t0 = DataRepository.AddressTypeProvider.GetByName(tm, entity.Name);
				AddressType t1 = DataRepository.AddressTypeProvider.GetByRowguid(tm, entity.Rowguid);
				AddressType t2 = DataRepository.AddressTypeProvider.GetByAddressTypeId(tm, entity.AddressTypeId);
			}
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				
				AddressType entity = mock.Copy() as AddressType;
				entity = (AddressType)mock.Clone();
				Assert.IsTrue(AddressType.ValueEquals(entity, mock), "Clone is not working");
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
				AddressType mock = CreateMockInstance(tm);
				bool result = DataRepository.AddressTypeProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				AddressTypeQuery query = new AddressTypeQuery();
			
				query.AppendEquals(AddressTypeColumn.AddressTypeId, mock.AddressTypeId.ToString());
				query.AppendEquals(AddressTypeColumn.Name, mock.Name.ToString());
				query.AppendEquals(AddressTypeColumn.Rowguid, mock.Rowguid.ToString());
				query.AppendEquals(AddressTypeColumn.ModifiedDate, mock.ModifiedDate.ToString());
				
				TList<AddressType> results = DataRepository.AddressTypeProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed AddressType Entity with mock values.
		///</summary>
		static public AddressType CreateMockInstance_Generated(TransactionManager tm)
		{		
			AddressType mock = new AddressType();
						
			mock.Name = TestUtility.Instance.RandomString(24, false);;
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();
			
		
			// create a temporary collection and add the item to it
			TList<AddressType> tempMockCollection = new TList<AddressType>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (AddressType)mock;
		}
		
		
		///<summary>
		///  Update the Typed AddressType Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, AddressType mock)
		{
			mock.Name = TestUtility.Instance.RandomString(24, false);;
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();
			
		}
		#endregion
    }
}
