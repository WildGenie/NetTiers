﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file VAdditionalContactInfoTest.cs instead.
*/
#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="VAdditionalContactInfo"/> objects (entity, collection and repository).
    /// </summary>
    public partial class VAdditionalContactInfoTest
    {
    	// the VAdditionalContactInfo instance used to test the repository.
		private VAdditionalContactInfo mock;
		
		// the VList<VAdditionalContactInfo> instance used to test the repository.
		private VList<VAdditionalContactInfo> mockCollection;		

        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>
        static private void Init_Generated()
        {
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the VAdditionalContactInfo Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
        static private void CleanUp_Generated()
        {       	
			System.Console.WriteLine();
			System.Console.WriteLine();
        }
		
		/// <summary>
		/// Selects a page of VAdditionalContactInfo objects from the database.
		/// </summary>
		private void Step_1_SelectAll_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.VAdditionalContactInfoProvider.GetPaged(null, 0, 10, out count);
			Assert.IsTrue(count >= 0, "Select Query Failed with GetPaged");
			System.Console.WriteLine("DataRepository.VAdditionalContactInfoProvider.GetPaged():");			
			System.Console.WriteLine(mockCollection);			
		}
		
		/// <summary>
		/// Searches some VAdditionalContactInfo objects from the database.
		/// </summary>
		private void Step_2_Search_Generated()
		{
			int count = -1;
			mockCollection = DataRepository.VAdditionalContactInfoProvider.Find(null, null, "", 0, 10, out count);
			Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
			
			System.Console.WriteLine("DataRepository.VAdditionalContactInfoProvider.Find():");			
			System.Console.WriteLine(mockCollection);
					
		}
		 //Find
			
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock VAdditionalContactInfo entity into a temporary file.
		/// </summary>
		private void Step_6_SerializeEntity_Generated()
		{
			string fileName = "temp_VAdditionalContactInfo.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VAdditionalContactInfo)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mock); 
			myWriter.Close();
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock VAdditionalContactInfo entity from a temporary file.
		/// </summary>
		private void Step_7_DeserializeEntity_Generated()
		{
			string fileName = "temp_VAdditionalContactInfo.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VAdditionalContactInfo)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			mock = (VAdditionalContactInfo) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a VAdditionalContactInfo collection into a temporary file.
		/// </summary>
		private void Step_8_SerializeCollection_Generated()
		{
			string fileName = "temp_VAdditionalContactInfoCollection.xml";
		
			VList<VAdditionalContactInfo> mockCollection = new VList<VAdditionalContactInfo>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<VAdditionalContactInfo>)); 
			System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("VList<VAdditionalContactInfo> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a VAdditionalContactInfo collection from a temporary file.
		/// </summary>
		private void Step_9_DeserializeCollection_Generated()
		{
			string fileName = "temp_VAdditionalContactInfoCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(VList<VAdditionalContactInfo>)); 
			System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open); 
			VList<VAdditionalContactInfo> mockCollection = (VList<VAdditionalContactInfo>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("VList<VAdditionalContactInfo> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		#region Mock Instance
		///<summary>
		///  Returns a Typed VAdditionalContactInfo Entity with mock values.
		///</summary>
		static public VAdditionalContactInfo CreateMockInstance()
		{		
			VAdditionalContactInfo mock = new VAdditionalContactInfo();
						
			mock.ContactId = TestUtility.Instance.RandomNumber();
			mock.FirstName = TestUtility.Instance.RandomString(24, false);;
			mock.MiddleName = TestUtility.Instance.RandomString(24, false);;
			mock.LastName = TestUtility.Instance.RandomString(24, false);;
			mock.TelephoneNumber = TestUtility.Instance.RandomString(24, false);;
			mock.TelephoneSpecialInstructions = TestUtility.Instance.RandomString(2, false);;
			mock.Street = TestUtility.Instance.RandomString(24, false);;
			mock.City = TestUtility.Instance.RandomString(24, false);;
			mock.StateProvince = TestUtility.Instance.RandomString(24, false);;
			mock.PostalCode = TestUtility.Instance.RandomString(24, false);;
			mock.CountryRegion = TestUtility.Instance.RandomString(24, false);;
			mock.HomeAddressSpecialInstructions = TestUtility.Instance.RandomString(2, false);;
			mock.EmailAddress = TestUtility.Instance.RandomString(63, false);;
			mock.EmailSpecialInstructions = TestUtility.Instance.RandomString(2, false);;
			mock.EmailTelephoneNumber = TestUtility.Instance.RandomString(24, false);;
			mock.Rowguid = Guid.NewGuid();
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();
		   return (VAdditionalContactInfo)mock;
		}
		

		#endregion
    }
}
