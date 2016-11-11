

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace Lite
{
	using Data = Dictionary<int, TemplateData>;
	using StrData = Dictionary<string, TemplateData>;

	public class TemplateManager : Singleton<TemplateManager>, IManager
	{
		private const int mJsonStartIndex = 5;
		private const int mColumnStartIndex = 1;


		private Dictionary<Type, Data> mDataPoolDic = new Dictionary<Type, Data>();
		private Dictionary<Type, StrData> mStrDataPoolDic = new Dictionary<Type, StrData>();

		private Dictionary<Type, string> tableList = new Dictionary<Type, string>();

		public void Register(Type type, string filePath)
		{
			tableList.Add(type, filePath);
		}

		public void Init()
		{
			Log.Info("loading teamlates...");

			IDictionaryEnumerator itor = tableList.GetEnumerator();
			while (itor.MoveNext())
			{
				string filePath = itor.Value as string;
				Log.Info(string.Format("load {0}...", filePath.Substring(filePath.LastIndexOf("Template"))));
				LoadRes(itor.Key as Type, itor.Value as string);
			}

			Log.Info("load teamlate done.");
		}

		public void Destroy()
		{
			foreach (var node in mDataPoolDic)
				node.Value.Clear();
			mDataPoolDic.Clear();

			foreach (var node in mStrDataPoolDic)
				node.Value.Clear();
			mStrDataPoolDic.Clear();
		}

		public void LoadRes(Type type, string path)
		{
			if (string.IsNullOrEmpty(path))
				return;

			if (mDataPoolDic.ContainsKey(type) || mStrDataPoolDic.ContainsKey(type))
				return;

			try
			{
				string rawText = System.IO.File.ReadAllText(path);

				Dictionary<int, TemplateData> dic = new Dictionary<int, TemplateData>();
				Dictionary<string, TemplateData> strDic = new Dictionary<string, TemplateData>();
				mDataPoolDic.Add(type, dic);
				mStrDataPoolDic.Add(type, strDic);

				TabReader tabReader = new TabReader();
				tabReader.Load(rawText);
				int JsonNodeCount = tabReader.RowCount;
				for (int i = mJsonStartIndex; i < JsonNodeCount; i++)
				{
					try
					{
						System.Reflection.ConstructorInfo conInfo = type.GetConstructor(Type.EmptyTypes);
						TemplateData t = conInfo.Invoke(null) as TemplateData;

						t.init(tabReader, i, mColumnStartIndex);
						if (0 != t.id)
						{
							if (!dic.ContainsKey(t.id))
								dic.Add(t.id, t);
							else
								Log.Error("Config Data Ready Exist, TableName: " + t.GetType().Name + " ID:" + t.id);
						}
						else
						{
							if (!strDic.ContainsKey(t.strId))
								strDic.Add(t.strId, t);
							else
								Log.Error("Config Data Ready Exist, TableName: " + t.GetType().Name + " ID:" + t.strId);
						}
					}
					catch (Exception e)
					{
						Log.Error(type.ToString() + " ERROR!!! line " + (i + 2).ToString() + ", " + e.ToString());
					}
				}

			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}

		public TemplateData GetDataByKey(Type type, int key)
		{
			if (mDataPoolDic.ContainsKey(type) && GetDataPool(type).ContainsKey(key))
			{
				return GetDataPool(type)[key];
			}
			if (key > 0)
			{
				Log.Error("Config Data Is Null : " + type.Name + " key: " + key);
			}
			return null;
		}

		public TemplateData GetDataByKey(Type type, string strKey)
		{
			if (mStrDataPoolDic.ContainsKey(type) && GetStrDataPool(type).ContainsKey(strKey))
			{
				return GetStrDataPool(type)[strKey];
			}

			Log.Error("Config Data Is Null : " + type.Name + " key: " + strKey);
			return null;
		}

		public T GetDataByKey<T>(int key) where T : TemplateData
		{
			return GetDataByKey(typeof(T), key) as T;
		}

		public T GetDataByKey<T>(string strKey) where T : TemplateData
		{
			return GetDataByKey(typeof(T), strKey) as T;
		}

		public Dictionary<int, TemplateData> GetDataPool<T>()
		{
			return GetDataPool(typeof(T));
		}

		public Dictionary<string, TemplateData> GetStrDataPool<T>()
		{
			return GetStrDataPool(typeof(T));
		}

		public Dictionary<int, TemplateData> GetDataPool(Type type)
		{
			if (mDataPoolDic.ContainsKey(type))
			{
				return mDataPoolDic[type];
			}

			return null;
		}

		public Dictionary<string, TemplateData> GetStrDataPool(Type type)
		{
			if (mStrDataPoolDic.ContainsKey(type))
			{
				return mStrDataPoolDic[type];
			}

			return null;
		}

	}
}
