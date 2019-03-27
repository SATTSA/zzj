﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1022
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.DAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Runtime.Serialization;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ws_message")]
	public partial class DataMessageDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertFriends(Friends instance);
    partial void UpdateFriends(Friends instance);
    partial void DeleteFriends(Friends instance);
    partial void InsertUsers(Users instance);
    partial void UpdateUsers(Users instance);
    partial void DeleteUsers(Users instance);
    partial void InsertMessages(Messages instance);
    partial void UpdateMessages(Messages instance);
    partial void DeleteMessages(Messages instance);
    partial void InsertGroupMembers(GroupMembers instance);
    partial void UpdateGroupMembers(GroupMembers instance);
    partial void DeleteGroupMembers(GroupMembers instance);
    partial void InsertGroups(Groups instance);
    partial void UpdateGroups(Groups instance);
    partial void DeleteGroups(Groups instance);
    #endregion
		
		public DataMessageDataContext() : 
				base(global::Web.DAL.Properties.Settings.Default.ws_messageConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataMessageDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataMessageDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataMessageDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataMessageDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Friends> Friends
		{
			get
			{
				return this.GetTable<Friends>();
			}
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
		
		public System.Data.Linq.Table<Messages> Messages
		{
			get
			{
				return this.GetTable<Messages>();
			}
		}
		
		public System.Data.Linq.Table<GroupMembers> GroupMembers
		{
			get
			{
				return this.GetTable<GroupMembers>();
			}
		}
		
		public System.Data.Linq.Table<Groups> Groups
		{
			get
			{
				return this.GetTable<Groups>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Friends")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Friends : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _UserName;
		
		private string _FriendName;
		
		private System.Nullable<bool> _IsPass;
		
		private EntityRef<Users> _Users;
		
		private EntityRef<Users> _Users1;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnFriendNameChanging(string value);
    partial void OnFriendNameChanged();
    partial void OnIsPassChanging(System.Nullable<bool> value);
    partial void OnIsPassChanged();
    #endregion
		
		public Friends()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(20)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					if (this._Users1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FriendName", DbType="VarChar(20)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string FriendName
		{
			get
			{
				return this._FriendName;
			}
			set
			{
				if ((this._FriendName != value))
				{
					if (this._Users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFriendNameChanging(value);
					this.SendPropertyChanging();
					this._FriendName = value;
					this.SendPropertyChanged("FriendName");
					this.OnFriendNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsPass", DbType="Bit")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public System.Nullable<bool> IsPass
		{
			get
			{
				return this._IsPass;
			}
			set
			{
				if ((this._IsPass != value))
				{
					this.OnIsPassChanging(value);
					this.SendPropertyChanging();
					this._IsPass = value;
					this.SendPropertyChanged("IsPass");
					this.OnIsPassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Friends", Storage="_Users", ThisKey="FriendName", OtherKey="Nickname", IsForeignKey=true)]
		internal Users Users
		{
			get
			{
				return this._Users.Entity;
			}
			set
			{
				Users previousValue = this._Users.Entity;
				if (((previousValue != value) 
							|| (this._Users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users.Entity = null;
						previousValue.Friends.Remove(this);
					}
					this._Users.Entity = value;
					if ((value != null))
					{
						value.Friends.Add(this);
						this._FriendName = value.Nickname;
					}
					else
					{
						this._FriendName = default(string);
					}
					this.SendPropertyChanged("Users");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Friends1", Storage="_Users1", ThisKey="UserName", OtherKey="Nickname", IsForeignKey=true)]
		internal Users Users1
		{
			get
			{
				return this._Users1.Entity;
			}
			set
			{
				Users previousValue = this._Users1.Entity;
				if (((previousValue != value) 
							|| (this._Users1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users1.Entity = null;
						previousValue.Friends1.Remove(this);
					}
					this._Users1.Entity = value;
					if ((value != null))
					{
						value.Friends1.Add(this);
						this._UserName = value.Nickname;
					}
					else
					{
						this._UserName = default(string);
					}
					this.SendPropertyChanged("Users1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			this._Users = default(EntityRef<Users>);
			this._Users1 = default(EntityRef<Users>);
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Users : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Nickname;
		
		private string _Password;
		
		private bool _IsOnline;
		
		private EntitySet<Friends> _Friends;
		
		private EntitySet<Friends> _Friends1;
		
		private EntitySet<Messages> _Messages;
		
		private EntitySet<Messages> _Messages1;
		
		private EntitySet<GroupMembers> _GroupMembers;
		
		private EntitySet<Groups> _Groups;
		
		private bool serializing;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNicknameChanging(string value);
    partial void OnNicknameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnIsOnlineChanging(bool value);
    partial void OnIsOnlineChanged();
    #endregion
		
		public Users()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nickname", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string Nickname
		{
			get
			{
				return this._Nickname;
			}
			set
			{
				if ((this._Nickname != value))
				{
					this.OnNicknameChanging(value);
					this.SendPropertyChanging();
					this._Nickname = value;
					this.SendPropertyChanged("Nickname");
					this.OnNicknameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsOnline")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public bool IsOnline
		{
			get
			{
				return this._IsOnline;
			}
			set
			{
				if ((this._IsOnline != value))
				{
					this.OnIsOnlineChanging(value);
					this.SendPropertyChanging();
					this._IsOnline = value;
					this.SendPropertyChanged("IsOnline");
					this.OnIsOnlineChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Friends", Storage="_Friends", ThisKey="Nickname", OtherKey="FriendName")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5, EmitDefaultValue=false)]
		public EntitySet<Friends> Friends
		{
			get
			{
				if ((this.serializing 
							&& (this._Friends.HasLoadedOrAssignedValues == false)))
				{
					return null;
				}
				return this._Friends;
			}
			set
			{
				this._Friends.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Friends1", Storage="_Friends1", ThisKey="Nickname", OtherKey="UserName")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6, EmitDefaultValue=false)]
		public EntitySet<Friends> Friends1
		{
			get
			{
				if ((this.serializing 
							&& (this._Friends1.HasLoadedOrAssignedValues == false)))
				{
					return null;
				}
				return this._Friends1;
			}
			set
			{
				this._Friends1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Messages", Storage="_Messages", ThisKey="Nickname", OtherKey="Receiver")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7, EmitDefaultValue=false)]
		public EntitySet<Messages> Messages
		{
			get
			{
				if ((this.serializing 
							&& (this._Messages.HasLoadedOrAssignedValues == false)))
				{
					return null;
				}
				return this._Messages;
			}
			set
			{
				this._Messages.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Messages1", Storage="_Messages1", ThisKey="Nickname", OtherKey="Sender")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=8, EmitDefaultValue=false)]
		public EntitySet<Messages> Messages1
		{
			get
			{
				if ((this.serializing 
							&& (this._Messages1.HasLoadedOrAssignedValues == false)))
				{
					return null;
				}
				return this._Messages1;
			}
			set
			{
				this._Messages1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_GroupMembers", Storage="_GroupMembers", ThisKey="Nickname", OtherKey="GroupMember")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=9, EmitDefaultValue=false)]
		public EntitySet<GroupMembers> GroupMembers
		{
			get
			{
				if ((this.serializing 
							&& (this._GroupMembers.HasLoadedOrAssignedValues == false)))
				{
					return null;
				}
				return this._GroupMembers;
			}
			set
			{
				this._GroupMembers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Groups", Storage="_Groups", ThisKey="Nickname", OtherKey="GroupMaster")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=10, EmitDefaultValue=false)]
		public EntitySet<Groups> Groups
		{
			get
			{
				if ((this.serializing 
							&& (this._Groups.HasLoadedOrAssignedValues == false)))
				{
					return null;
				}
				return this._Groups;
			}
			set
			{
				this._Groups.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Friends(Friends entity)
		{
			this.SendPropertyChanging();
			entity.Users = this;
		}
		
		private void detach_Friends(Friends entity)
		{
			this.SendPropertyChanging();
			entity.Users = null;
		}
		
		private void attach_Friends1(Friends entity)
		{
			this.SendPropertyChanging();
			entity.Users1 = this;
		}
		
		private void detach_Friends1(Friends entity)
		{
			this.SendPropertyChanging();
			entity.Users1 = null;
		}
		
		private void attach_Messages(Messages entity)
		{
			this.SendPropertyChanging();
			entity.Users = this;
		}
		
		private void detach_Messages(Messages entity)
		{
			this.SendPropertyChanging();
			entity.Users = null;
		}
		
		private void attach_Messages1(Messages entity)
		{
			this.SendPropertyChanging();
			entity.Users1 = this;
		}
		
		private void detach_Messages1(Messages entity)
		{
			this.SendPropertyChanging();
			entity.Users1 = null;
		}
		
		private void attach_GroupMembers(GroupMembers entity)
		{
			this.SendPropertyChanging();
			entity.Users = this;
		}
		
		private void detach_GroupMembers(GroupMembers entity)
		{
			this.SendPropertyChanging();
			entity.Users = null;
		}
		
		private void attach_Groups(Groups entity)
		{
			this.SendPropertyChanging();
			entity.Users = this;
		}
		
		private void detach_Groups(Groups entity)
		{
			this.SendPropertyChanging();
			entity.Users = null;
		}
		
		private void Initialize()
		{
			this._Friends = new EntitySet<Friends>(new Action<Friends>(this.attach_Friends), new Action<Friends>(this.detach_Friends));
			this._Friends1 = new EntitySet<Friends>(new Action<Friends>(this.attach_Friends1), new Action<Friends>(this.detach_Friends1));
			this._Messages = new EntitySet<Messages>(new Action<Messages>(this.attach_Messages), new Action<Messages>(this.detach_Messages));
			this._Messages1 = new EntitySet<Messages>(new Action<Messages>(this.attach_Messages1), new Action<Messages>(this.detach_Messages1));
			this._GroupMembers = new EntitySet<GroupMembers>(new Action<GroupMembers>(this.attach_GroupMembers), new Action<GroupMembers>(this.detach_GroupMembers));
			this._Groups = new EntitySet<Groups>(new Action<Groups>(this.attach_Groups), new Action<Groups>(this.detach_Groups));
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
		
		[global::System.Runtime.Serialization.OnSerializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnSerializing(StreamingContext context)
		{
			this.serializing = true;
		}
		
		[global::System.Runtime.Serialization.OnSerializedAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnSerialized(StreamingContext context)
		{
			this.serializing = false;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Messages")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Messages : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<int> _Classify;
		
		private string _Sender;
		
		private string _Receiver;
		
		private string _Details;
		
		private string _FileFullName;
		
		private System.Nullable<System.DateTime> _SendTime;
		
		private EntityRef<Users> _Users;
		
		private EntityRef<Users> _Users1;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnClassifyChanging(System.Nullable<int> value);
    partial void OnClassifyChanged();
    partial void OnSenderChanging(string value);
    partial void OnSenderChanged();
    partial void OnReceiverChanging(string value);
    partial void OnReceiverChanged();
    partial void OnDetailsChanging(string value);
    partial void OnDetailsChanged();
    partial void OnFileFullNameChanging(string value);
    partial void OnFileFullNameChanged();
    partial void OnSendTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnSendTimeChanged();
    #endregion
		
		public Messages()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Classify", DbType="Int")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public System.Nullable<int> Classify
		{
			get
			{
				return this._Classify;
			}
			set
			{
				if ((this._Classify != value))
				{
					this.OnClassifyChanging(value);
					this.SendPropertyChanging();
					this._Classify = value;
					this.SendPropertyChanged("Classify");
					this.OnClassifyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sender", DbType="VarChar(20)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string Sender
		{
			get
			{
				return this._Sender;
			}
			set
			{
				if ((this._Sender != value))
				{
					if (this._Users1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSenderChanging(value);
					this.SendPropertyChanging();
					this._Sender = value;
					this.SendPropertyChanged("Sender");
					this.OnSenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Receiver", DbType="VarChar(20)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public string Receiver
		{
			get
			{
				return this._Receiver;
			}
			set
			{
				if ((this._Receiver != value))
				{
					if (this._Users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnReceiverChanging(value);
					this.SendPropertyChanging();
					this._Receiver = value;
					this.SendPropertyChanged("Receiver");
					this.OnReceiverChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Details", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public string Details
		{
			get
			{
				return this._Details;
			}
			set
			{
				if ((this._Details != value))
				{
					this.OnDetailsChanging(value);
					this.SendPropertyChanging();
					this._Details = value;
					this.SendPropertyChanged("Details");
					this.OnDetailsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileFullName", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public string FileFullName
		{
			get
			{
				return this._FileFullName;
			}
			set
			{
				if ((this._FileFullName != value))
				{
					this.OnFileFullNameChanging(value);
					this.SendPropertyChanging();
					this._FileFullName = value;
					this.SendPropertyChanged("FileFullName");
					this.OnFileFullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SendTime", DbType="DateTime")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
		public System.Nullable<System.DateTime> SendTime
		{
			get
			{
				return this._SendTime;
			}
			set
			{
				if ((this._SendTime != value))
				{
					this.OnSendTimeChanging(value);
					this.SendPropertyChanging();
					this._SendTime = value;
					this.SendPropertyChanged("SendTime");
					this.OnSendTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Messages", Storage="_Users", ThisKey="Receiver", OtherKey="Nickname", IsForeignKey=true)]
		internal Users Users
		{
			get
			{
				return this._Users.Entity;
			}
			set
			{
				Users previousValue = this._Users.Entity;
				if (((previousValue != value) 
							|| (this._Users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users.Entity = null;
						previousValue.Messages.Remove(this);
					}
					this._Users.Entity = value;
					if ((value != null))
					{
						value.Messages.Add(this);
						this._Receiver = value.Nickname;
					}
					else
					{
						this._Receiver = default(string);
					}
					this.SendPropertyChanged("Users");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Messages1", Storage="_Users1", ThisKey="Sender", OtherKey="Nickname", IsForeignKey=true)]
		internal Users Users1
		{
			get
			{
				return this._Users1.Entity;
			}
			set
			{
				Users previousValue = this._Users1.Entity;
				if (((previousValue != value) 
							|| (this._Users1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users1.Entity = null;
						previousValue.Messages1.Remove(this);
					}
					this._Users1.Entity = value;
					if ((value != null))
					{
						value.Messages1.Add(this);
						this._Sender = value.Nickname;
					}
					else
					{
						this._Sender = default(string);
					}
					this.SendPropertyChanged("Users1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			this._Users = default(EntityRef<Users>);
			this._Users1 = default(EntityRef<Users>);
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.GroupMembers")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class GroupMembers : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _GroupName;
		
		private string _GroupMember;
		
		private bool _IsPass;
		
		private EntityRef<Users> _Users;
		
		private EntityRef<Groups> _Groups;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnGroupNameChanging(string value);
    partial void OnGroupNameChanged();
    partial void OnGroupMemberChanging(string value);
    partial void OnGroupMemberChanged();
    partial void OnIsPassChanging(bool value);
    partial void OnIsPassChanged();
    #endregion
		
		public GroupMembers()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupName", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public string GroupName
		{
			get
			{
				return this._GroupName;
			}
			set
			{
				if ((this._GroupName != value))
				{
					if (this._Groups.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnGroupNameChanging(value);
					this.SendPropertyChanging();
					this._GroupName = value;
					this.SendPropertyChanged("GroupName");
					this.OnGroupNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupMember", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string GroupMember
		{
			get
			{
				return this._GroupMember;
			}
			set
			{
				if ((this._GroupMember != value))
				{
					if (this._Users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnGroupMemberChanging(value);
					this.SendPropertyChanging();
					this._GroupMember = value;
					this.SendPropertyChanged("GroupMember");
					this.OnGroupMemberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsPass")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public bool IsPass
		{
			get
			{
				return this._IsPass;
			}
			set
			{
				if ((this._IsPass != value))
				{
					this.OnIsPassChanging(value);
					this.SendPropertyChanging();
					this._IsPass = value;
					this.SendPropertyChanged("IsPass");
					this.OnIsPassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_GroupMembers", Storage="_Users", ThisKey="GroupMember", OtherKey="Nickname", IsForeignKey=true)]
		internal Users Users
		{
			get
			{
				return this._Users.Entity;
			}
			set
			{
				Users previousValue = this._Users.Entity;
				if (((previousValue != value) 
							|| (this._Users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users.Entity = null;
						previousValue.GroupMembers.Remove(this);
					}
					this._Users.Entity = value;
					if ((value != null))
					{
						value.GroupMembers.Add(this);
						this._GroupMember = value.Nickname;
					}
					else
					{
						this._GroupMember = default(string);
					}
					this.SendPropertyChanged("Users");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Groups_GroupMembers", Storage="_Groups", ThisKey="GroupName", OtherKey="GroupName", IsForeignKey=true)]
		internal Groups Groups
		{
			get
			{
				return this._Groups.Entity;
			}
			set
			{
				Groups previousValue = this._Groups.Entity;
				if (((previousValue != value) 
							|| (this._Groups.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Groups.Entity = null;
						previousValue.GroupMembers.Remove(this);
					}
					this._Groups.Entity = value;
					if ((value != null))
					{
						value.GroupMembers.Add(this);
						this._GroupName = value.GroupName;
					}
					else
					{
						this._GroupName = default(string);
					}
					this.SendPropertyChanged("Groups");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void Initialize()
		{
			this._Users = default(EntityRef<Users>);
			this._Groups = default(EntityRef<Groups>);
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Groups")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Groups : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _GroupName;
		
		private string _GroupMaster;
		
		private EntitySet<GroupMembers> _GroupMembers;
		
		private EntityRef<Users> _Users;
		
		private bool serializing;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnGroupNameChanging(string value);
    partial void OnGroupNameChanged();
    partial void OnGroupMasterChanging(string value);
    partial void OnGroupMasterChanged();
    #endregion
		
		public Groups()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupName", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string GroupName
		{
			get
			{
				return this._GroupName;
			}
			set
			{
				if ((this._GroupName != value))
				{
					this.OnGroupNameChanging(value);
					this.SendPropertyChanging();
					this._GroupName = value;
					this.SendPropertyChanged("GroupName");
					this.OnGroupNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupMaster", DbType="VarChar(20)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string GroupMaster
		{
			get
			{
				return this._GroupMaster;
			}
			set
			{
				if ((this._GroupMaster != value))
				{
					if (this._Users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnGroupMasterChanging(value);
					this.SendPropertyChanging();
					this._GroupMaster = value;
					this.SendPropertyChanged("GroupMaster");
					this.OnGroupMasterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Groups_GroupMembers", Storage="_GroupMembers", ThisKey="GroupName", OtherKey="GroupName")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4, EmitDefaultValue=false)]
		public EntitySet<GroupMembers> GroupMembers
		{
			get
			{
				if ((this.serializing 
							&& (this._GroupMembers.HasLoadedOrAssignedValues == false)))
				{
					return null;
				}
				return this._GroupMembers;
			}
			set
			{
				this._GroupMembers.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_Groups", Storage="_Users", ThisKey="GroupMaster", OtherKey="Nickname", IsForeignKey=true)]
		internal Users Users
		{
			get
			{
				return this._Users.Entity;
			}
			set
			{
				Users previousValue = this._Users.Entity;
				if (((previousValue != value) 
							|| (this._Users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users.Entity = null;
						previousValue.Groups.Remove(this);
					}
					this._Users.Entity = value;
					if ((value != null))
					{
						value.Groups.Add(this);
						this._GroupMaster = value.Nickname;
					}
					else
					{
						this._GroupMaster = default(string);
					}
					this.SendPropertyChanged("Users");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_GroupMembers(GroupMembers entity)
		{
			this.SendPropertyChanging();
			entity.Groups = this;
		}
		
		private void detach_GroupMembers(GroupMembers entity)
		{
			this.SendPropertyChanging();
			entity.Groups = null;
		}
		
		private void Initialize()
		{
			this._GroupMembers = new EntitySet<GroupMembers>(new Action<GroupMembers>(this.attach_GroupMembers), new Action<GroupMembers>(this.detach_GroupMembers));
			this._Users = default(EntityRef<Users>);
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
		
		[global::System.Runtime.Serialization.OnSerializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnSerializing(StreamingContext context)
		{
			this.serializing = true;
		}
		
		[global::System.Runtime.Serialization.OnSerializedAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnSerialized(StreamingContext context)
		{
			this.serializing = false;
		}
	}
}
#pragma warning restore 1591