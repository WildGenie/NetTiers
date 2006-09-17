﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Monday, July 24, 2006
	Important: Do not modify this file. Edit the file Item.cs instead.
*/

#region using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace netTiers.Petshop.Entities
{
	#region ItemEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Item"/> object.
	/// </remarks>
	public class ItemEventArgs : System.EventArgs
	{
		private ItemColumn column;
		
		///<summary>
		/// Initalizes a new Instance of the ItemEventArgs class.
		///</summary>
		public ItemEventArgs(ItemColumn column)
		{
			this.column = column;
		}
		
		
		///<summary>
		/// The ItemColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="ItemColumn" />
		public ItemColumn Column { get { return this.column; } }
	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all Item related events.
	///</summary>
	public delegate void ItemEventHandler(object sender, ItemEventArgs e);
	
	///<summary>
	/// An object representation of the 'Item' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(Item))]
	public abstract partial class ItemBase : EntityBase, IEntityId<ItemKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private ItemEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//ItemEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private ItemEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<Item> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event ItemEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event ItemEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="ItemBase"/> instance.
		///</summary>
		public ItemBase()
		{
			this.entityData = new ItemEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="ItemBase"/> instance.
		///</summary>
		///<param name="itemId"></param>
		///<param name="itemName"></param>
		///<param name="itemDescription"></param>
		///<param name="itemPrice"></param>
		///<param name="itemCurrency"></param>
		///<param name="itemPhoto"></param>
		///<param name="itemProductId"></param>
		public ItemBase(System.Guid itemId, System.String itemName, System.String itemDescription, System.Double? itemPrice, 
			System.String itemCurrency, System.String itemPhoto, System.Guid itemProductId)
		{
			this.entityData = new ItemEntityData();
			this.backupData = null;

			this.Id = itemId;
			this.Name = itemName;
			this.Description = itemDescription;
			this.Price = itemPrice;
			this.Currency = itemCurrency;
			this.Photo = itemPhoto;
			this.ProductId = itemProductId;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Item"/> instance.
		///</summary>
		///<param name="itemId"></param>
		///<param name="itemName"></param>
		///<param name="itemDescription"></param>
		///<param name="itemPrice"></param>
		///<param name="itemCurrency"></param>
		///<param name="itemPhoto"></param>
		///<param name="itemProductId"></param>
		public static Item CreateItem(System.Guid itemId, System.String itemName, System.String itemDescription, System.Double? itemPrice, 
			System.String itemCurrency, System.String itemPhoto, System.Guid itemProductId)
		{
			Item newItem = new Item();
			newItem.Id = itemId;
			newItem.Name = itemName;
			newItem.Description = itemDescription;
			newItem.Price = itemPrice;
			newItem.Currency = itemCurrency;
			newItem.Photo = itemPhoto;
			newItem.ProductId = itemProductId;
			return newItem;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ItemColumn"/> which has raised the event.</param>
		public void OnColumnChanging(ItemColumn column)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				ItemEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new ItemEventArgs(column));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="ItemColumn"/> which has raised the event.</param>
		public void OnColumnChanged(ItemColumn column)
		{
			if (!SuppressEntityEvents)
			{
				ItemEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new ItemEventArgs(column));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the Id property. 
		///		
		/// </summary>
		/// <value>This type is uniqueidentifier.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true,false,false)]
		public virtual System.Guid Id
		{
			get
			{
				return this.entityData.Id; 
			}
			
			set
			{
				if (this.entityData.Id == value)
					return;
					
					
				OnColumnChanging(ItemColumn.Id);
				this.entityData.Id = value;
				this.EntityId.Id = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ItemColumn.Id);
				OnPropertyChanged("Id");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the Id property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the Id property.</remarks>
		/// <value>This type is uniqueidentifier</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Guid OriginalId
		{
			get { return this.entityData.OriginalId; }
			set { this.entityData.OriginalId = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the Name property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false, 255)]
		public virtual System.String Name
		{
			get
			{
				return this.entityData.Name; 
			}
			
			set
			{
				if (this.entityData.Name == value)
					return;
					
					
				OnColumnChanging(ItemColumn.Name);
				this.entityData.Name = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ItemColumn.Name);
				OnPropertyChanged("Name");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Description property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,true, 255)]
		public virtual System.String Description
		{
			get
			{
				return this.entityData.Description; 
			}
			
			set
			{
				if (this.entityData.Description == value)
					return;
					
					
				OnColumnChanging(ItemColumn.Description);
				this.entityData.Description = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ItemColumn.Description);
				OnPropertyChanged("Description");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Price property. 
		///		
		/// </summary>
		/// <value>This type is float.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return 0.0f. It is up to the developer
		/// to check the value of IsPriceNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,true)]
		public virtual System.Double? Price
		{
			get
			{
				return this.entityData.Price; 
			}
			
			set
			{
				if (this.entityData.Price == value && this.entityData.Price != null )
					return;
					
					
				OnColumnChanging(ItemColumn.Price);
				this.entityData.Price = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ItemColumn.Price);
				OnPropertyChanged("Price");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Currency property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,true, 255)]
		public virtual System.String Currency
		{
			get
			{
				return this.entityData.Currency; 
			}
			
			set
			{
				if (this.entityData.Currency == value)
					return;
					
					
				OnColumnChanging(ItemColumn.Currency);
				this.entityData.Currency = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ItemColumn.Currency);
				OnPropertyChanged("Currency");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Photo property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,true, 255)]
		public virtual System.String Photo
		{
			get
			{
				return this.entityData.Photo; 
			}
			
			set
			{
				if (this.entityData.Photo == value)
					return;
					
					
				OnColumnChanging(ItemColumn.Photo);
				this.entityData.Photo = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ItemColumn.Photo);
				OnPropertyChanged("Photo");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ProductId property. 
		///		
		/// </summary>
		/// <value>This type is uniqueidentifier.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false)]
		public virtual System.Guid ProductId
		{
			get
			{
				return this.entityData.ProductId; 
			}
			
			set
			{
				if (this.entityData.ProductId == value)
					return;
					
					
				OnColumnChanging(ItemColumn.ProductId);
				this.entityData.ProductId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ItemColumn.ProductId);
				OnPropertyChanged("ProductId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Timestamp property. 
		///		
		/// </summary>
		/// <value>This type is timestamp.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false)]
		public virtual System.Byte[] Timestamp
		{
			get
			{
				return this.entityData.Timestamp; 
			}
			
			set
			{
				if (this.entityData.Timestamp == value)
					return;
					
					
				OnColumnChanging(ItemColumn.Timestamp);
				this.entityData.Timestamp = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(ItemColumn.Timestamp);
				OnPropertyChanged("Timestamp");
			}
		}
		

		#region Source Foreign Key Property
				
		private Product _productIdSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Product"/>.
		/// </summary>
		/// <value>The source Product for ProductId.</value>
		[Browsable(false), BindableAttribute()]
		public virtual Product ProductIdSource
      	{
            get { return this._productIdSource; }
            set { this._productIdSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "Item"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"Id", "Name", "Description", "Price", "Currency", "Photo", "ProductId", "Timestamp"};
			}
		}
		#endregion 
		
	
		/// <summary>
		///	Holds a collection of LineItem objects
		///	which are related to this object through the relation FK_LineItem_Item
		/// </summary>	
		[BindableAttribute()]
		public TList<LineItem> LineItemCollection
		{
			get { return entityData.LineItemCollection; }
			set { entityData.LineItemCollection = value; }	
		}
	
		/// <summary>
		///	Holds a collection of Inventory objects
		///	which are related to this object through the relation FK_Inventory_Item
		/// </summary>	
		[BindableAttribute()]
		public TList<Inventory> InventoryCollection
		{
			get { return entityData.InventoryCollection; }
			set { entityData.InventoryCollection = value; }	
		}

		/// <summary>
		///	Holds a collection of SupplierFromInventory objects
		///	which are related to this object through the junction table Inventory
		/// </summary>	
		[BindableAttribute()]
		public TList<Supplier> SupplierCollection_From_Inventory
		{
			get { return entityData.SupplierCollection_From_Inventory; }
			set { entityData.SupplierCollection_From_Inventory = value; }	
		}
		
		#endregion
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as ItemEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (Item) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return (object)this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = (TList<Item>)value;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Item);
	        }
	    }


		#endregion
		
		#region Methods	
			
		///<summary>
		///  TODO: Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public override void CancelChanges()
		{
			throw new NotImplementedException("Method currently not Supported.");
		}	
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed Item Entity 
		///</summary>
		public virtual Item Copy()
		{
			//shallow copy entity
			Item copy = new Item();
			copy.Id = this.Id;
			copy.OriginalId = this.OriginalId;
			copy.Name = this.Name;
			copy.Description = this.Description;
			copy.Price = this.Price;
			copy.Currency = this.Currency;
			copy.Photo = this.Photo;
			copy.ProductId = this.ProductId;
			copy.Timestamp = this.Timestamp;
					
			copy.AcceptChanges();
			return (Item)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		///  Returns a Typed Item Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Item DeepCopy()
		{
			return EntityHelper.Clone<Item>(this as Item);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="ItemBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(ItemBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="ItemBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="ItemBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="ItemBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(ItemBase Object1, ItemBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.Id != Object2.Id)
				equal = false;
			if (Object1.Name != Object2.Name)
				equal = false;
			if ( Object1.Description != null && Object2.Description != null )
			{
				if (Object1.Description != Object2.Description)
					equal = false;
			}
			else if (Object1.Description == null ^ Object1.Description == null )
			{
				equal = false;
			}
			if ( Object1.Price != null && Object2.Price != null )
			{
				if (Object1.Price != Object2.Price)
					equal = false;
			}
			else if (Object1.Price == null ^ Object1.Price == null )
			{
				equal = false;
			}
			if ( Object1.Currency != null && Object2.Currency != null )
			{
				if (Object1.Currency != Object2.Currency)
					equal = false;
			}
			else if (Object1.Currency == null ^ Object1.Currency == null )
			{
				equal = false;
			}
			if ( Object1.Photo != null && Object2.Photo != null )
			{
				if (Object1.Photo != Object2.Photo)
					equal = false;
			}
			else if (Object1.Photo == null ^ Object1.Photo == null )
			{
				equal = false;
			}
			if (Object1.ProductId != Object2.ProductId)
				equal = false;
			if (Object1.Timestamp != Object2.Timestamp)
				equal = false;
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			// TODO -> generate a strongly typed IComparer in the concrete class
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((ItemBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static ItemComparer GetComparer()
        {
            return new ItemComparer();
        }
        */

        // Comparer delegates back to Item
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(Item rhs, ItemColumn which)
        {
            switch (which)
            {
            	
            	
            	case ItemColumn.Id:
            		return this.Id.CompareTo(rhs.Id);
            		
            		                 
            	
            	
            	case ItemColumn.Name:
            		return this.Name.CompareTo(rhs.Name);
            		
            		                 
            	
            	
            	case ItemColumn.Description:
            		return this.Description.CompareTo(rhs.Description);
            		
            		                 
            	
            	
            	case ItemColumn.Price:
            		return this.Price.Value.CompareTo(rhs.Price.Value);
            		
            		                 
            	
            	
            	case ItemColumn.Currency:
            		return this.Currency.CompareTo(rhs.Currency);
            		
            		                 
            	
            	
            	case ItemColumn.Photo:
            		return this.Photo.CompareTo(rhs.Photo);
            		
            		                 
            	
            	
            	case ItemColumn.ProductId:
            		return this.ProductId.CompareTo(rhs.ProductId);
            		
            		                 
            	
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<ItemKey> Members
		
		// member variable for the EntityId property
		private ItemKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public ItemKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new ItemKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = @"Item" 
					+ this.Id.ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{9}{8}- Id: {0}{8}- Name: {1}{8}- Description: {2}{8}- Price: {3}{8}- Currency: {4}{8}- Photo: {5}{8}- ProductId: {6}{8}- Timestamp: {7}{8}", 
				this.Id,
				this.Name,
				(this.Description == null) ? string.Empty : this.Description.ToString(),
				(this.Price == null) ? string.Empty : this.Price.ToString(),
				(this.Currency == null) ? string.Empty : this.Currency.ToString(),
				(this.Photo == null) ? string.Empty : this.Photo.ToString(),
				this.ProductId,
				this.Timestamp,
				Environment.NewLine, 
				this.GetType());
		}
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'Item' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class ItemEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// Id : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "Item"</remarks>
			public System.Guid Id;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Guid OriginalId;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		public System.String		  Name = string.Empty;
		
		/// <summary>
		/// Description : 
		/// </summary>
		public System.String		  Description = null;
		
		/// <summary>
		/// Price : 
		/// </summary>
		public System.Double?		  Price = null;
		
		/// <summary>
		/// Currency : 
		/// </summary>
		public System.String		  Currency = null;
		
		/// <summary>
		/// Photo : 
		/// </summary>
		public System.String		  Photo = null;
		
		/// <summary>
		/// ProductId : 
		/// </summary>
		public System.Guid		  ProductId = Guid.Empty;
		
		/// <summary>
		/// Timestamp : 
		/// </summary>
		public System.Byte[]		  Timestamp = new byte[] {};
		#endregion
			
		#endregion "Variable Declarations"
		
		public Object Clone()
		{
			ItemEntityData _tmp = new ItemEntityData();
						
			_tmp.Id = this.Id;
			_tmp.OriginalId = this.OriginalId;
			
			_tmp.Name = this.Name;
			_tmp.Description = this.Description;
			_tmp.Price = this.Price;
			_tmp.Currency = this.Currency;
			_tmp.Photo = this.Photo;
			_tmp.ProductId = this.ProductId;
			_tmp.Timestamp = this.Timestamp;
			
			return _tmp;
		}
		

		private TList<LineItem> lineItem;
      public TList<LineItem> LineItemCollection
      {
         get
         {
            if (lineItem == null)
            {
               lineItem = new TList<LineItem>();
            }

            return lineItem;
         }
         set { lineItem = value; }
      }

		private TList<Inventory> inventory;
      public TList<Inventory> InventoryCollection
      {
         get
         {
            if (inventory == null)
            {
               inventory = new TList<Inventory>();
            }

            return inventory;
         }
         set { inventory = value; }
      }

		private TList<Supplier> supplier;
      public TList<Supplier> SupplierCollection_From_Inventory
      {
         get
         {
            if (supplier == null)
            {
               supplier = new TList<Supplier>();
            }

            return supplier;
         }
         set { supplier = value; }
      }
	}//End struct


		#endregion
		
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Name");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Name",255));
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Description",255));
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Currency",255));
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Photo",255));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Timestamp");
		}
   		#endregion
	
	} // End Class
	
	#region ItemComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class ItemComparer : System.Collections.Generic.IComparer<Item>
	{
		ItemColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:ItemComparer"/> class.
        /// </summary>
		public ItemComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public ItemComparer(ItemColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="Item"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="Item"/> to compare.</param>
        /// <param name="b">The second <c>Item</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Item a, Item b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Item entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Item a, Item b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public ItemColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region ItemKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="Item"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class ItemKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the ItemKey class.
		/// </summary>
		public ItemKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the ItemKey class.
		/// </summary>
		public ItemKey(ItemBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.id = entity.Id;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the ItemKey class.
		/// </summary>
		public ItemKey(System.Guid id)
		{
			#region Init Properties

			this.id = id;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private ItemBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public ItemBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the Id property
		private System.Guid id;
		
		/// <summary>
		/// Gets or sets the Id property.
		/// </summary>
		public System.Guid Id
		{
			get { return id; }
			set
			{
				if ( Entity != null )
				{
					Entity.Id = value;
				}
				
				id = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				Id = ( values["Id"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Id"], typeof(System.Guid)) : Guid.Empty;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("Id", Id);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("Id: {0}{1}",
								Id,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	
	
	/// <summary>
	/// Enumerate the Item columns.
	/// </summary>
	[Serializable]
	public enum ItemColumn
	{
		/// <summary>
		/// Id : 
		/// </summary>
		[EnumTextValue("Id")]
		Id,
		/// <summary>
		/// Name : 
		/// </summary>
		[EnumTextValue("Name")]
		Name,
		/// <summary>
		/// Description : 
		/// </summary>
		[EnumTextValue("Description")]
		Description,
		/// <summary>
		/// Price : 
		/// </summary>
		[EnumTextValue("Price")]
		Price,
		/// <summary>
		/// Currency : 
		/// </summary>
		[EnumTextValue("Currency")]
		Currency,
		/// <summary>
		/// Photo : 
		/// </summary>
		[EnumTextValue("Photo")]
		Photo,
		/// <summary>
		/// ProductId : 
		/// </summary>
		[EnumTextValue("ProductId")]
		ProductId,
		/// <summary>
		/// Timestamp : 
		/// </summary>
		[EnumTextValue("Timestamp")]
		Timestamp
	}//End enum

} // end namespace


